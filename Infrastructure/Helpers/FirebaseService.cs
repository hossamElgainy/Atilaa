using Core.DomaimModels;
using Core.DomainModels;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Core.Interfaces.Specifications;
using Domain.DomaimModels;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Hangfire;
using Infrastructure.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
namespace Infrastructure.Helpers
{
    public class FirebaseService 
    {
        private static readonly object Lock = new object();
        private static bool _isInitialized = false;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public FirebaseService(IUnitOfWork unitOfWork, IServiceScopeFactory serviceScopeFactory, IBackgroundJobClient backgroundJobClient)
        {
            _unitOfWork = unitOfWork;
            _serviceScopeFactory = serviceScopeFactory;
            _backgroundJobClient = backgroundJobClient;
            InitializeFirebase();
        }

        private void InitializeFirebase()
        {
            if (_isInitialized) return;

            lock (Lock)
            {
                if (_isInitialized) return;

                var pathToKey = Path.Combine(Directory.GetCurrentDirectory(), "config",
                    "blink-mart-firebase-adminsdk-fbsvc-272d0abcbc.json");

                if (!File.Exists(pathToKey))
                {
                    _isInitialized = true;
                    return;
                }

                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile(pathToKey)
                });

                _isInitialized = true;
            }
        }

        // ====================== SEND TO SINGLE USER (All Devices) ======================
        public async Task<string> SendNotificationToUserAsync(int userId, string title, string body,
            int serviceId, ServicesEnum serviceName, string appType = "Player")
        {
            var clientTypes = GetClientTypes(appType);
            var tokens = await _unitOfWork.Repository<RefreshToken>()
                .GetAllByProAsync(t => t.UserId == userId
                               && t.FcmToken != null
                               && t.FcmToken != string.Empty
                               && t.IsActive
                               && clientTypes.Contains(t.ClientType));

            var tokenList = tokens.Select(t => t.FcmToken!).ToList();

            if (!tokenList.Any())
                return "No active FCM tokens found for this user.";

            var message = new MulticastMessage
            {
                Tokens = tokenList,
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                },
                Data = new Dictionary<string, string>
                {
                    { "Id", serviceId.ToString() },
                    { "DateTime", DateTime.UtcNow.ToString("dd MMM yyyy hh:mm tt", CultureInfo.InvariantCulture).ToUpper() },
                    { "ServiceName", serviceName.ToString() },
                    { "AppType", appType }
                }
            };

            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message);

                // Save notification history
                var notification = new NotificationModel
                {
                    Title = title,
                    Body = body,
                    UserId = userId,
                    ServiceId = serviceId,
                    ServiceName = serviceName,
                    Date = DateTime.UtcNow,
                };

                await _unitOfWork.Repository<NotificationModel>().AddAsync(notification);
                await _unitOfWork.Complete();
                _backgroundJobClient.Schedule<NotificationsCleanupJob>(
                    job => job.DeleteNotificationByIdAsync(notification.Id),
                    DateTimeOffset.UtcNow.AddMonths(3));

                // Clean invalid tokens automatically
                if (response.FailureCount > 0)
                {
                    await CleanInvalidTokensAsync(response, tokens.ToList());
                }

                return $"Sent successfully to {response.SuccessCount} device(s). Failed: {response.FailureCount}";
            }
            catch (Exception ex)
            {
                LogError(ex);
                return $"Error sending notification: {ex.Message}";
            }
        }

        // ====================== SEND TO MULTIPLE USERS ======================
        public async Task<string> SendNotificationToGroupAsync(List<int> userIds, string title, string body,
            int serviceId, ServicesEnum serviceName, string appType = "Player")
        {
            var clientTypes = GetClientTypes(appType);
            var tokens = await _unitOfWork.Repository<RefreshToken>()
                .GetAllByProAsync(t => userIds.Contains(t.UserId)
                               && t.FcmToken != null
                               && t.FcmToken != string.Empty
                               && t.IsActive
                               && clientTypes.Contains(t.ClientType));

            var tokenList = tokens.Select(t => t.FcmToken!).ToList();

            if (!tokenList.Any())
                return "No active tokens found";

            var message = new MulticastMessage
            {
                Tokens = tokenList,
                Notification = new Notification { Title = title, Body = body },
                Data = new Dictionary<string, string>
                {
                    { "Id", serviceId.ToString() },
                    { "DateTime", DateTime.UtcNow.ToString("dd MMM yyyy hh:mm tt", CultureInfo.InvariantCulture).ToUpper() },
                    { "ServiceName", serviceName.ToString() },
                    { "AppType", appType }
                }
            };

            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message);

                var notifications = userIds.Select(uid => new NotificationModel
                {
                    Title = title,
                    Body = body,
                    UserId = uid,
                    ServiceId = serviceId,
                    ServiceName = serviceName,
                    Date = DateTime.UtcNow,
                }).ToList();

                _unitOfWork.Repository<NotificationModel>().AddRangeAsync(notifications);
                await _unitOfWork.Complete();
                foreach (var notification in notifications)
                {
                    _backgroundJobClient.Schedule<NotificationsCleanupJob>(
                        job => job.DeleteNotificationByIdAsync(notification.Id),
                        DateTimeOffset.UtcNow.AddMonths(3));
                }

                if (response.FailureCount > 0)
                    await CleanInvalidTokensAsync(response, tokens.ToList());

                return $"Success: {response.SuccessCount}, Failed: {response.FailureCount}";
            }
            catch (Exception ex)
            {
                LogError(ex);
                return $"Error: {ex.Message}";
            }
        }

        // ====================== CLEAN INVALID TOKENS ======================
        private async Task CleanInvalidTokensAsync(BatchResponse response, List<RefreshToken> tokens)
        {
            for (int i = 0; i < response.Responses.Count; i++)
            {
                if (!response.Responses[i].IsSuccess)
                {
                    var errorCode = response.Responses[i].Exception?.MessagingErrorCode;
                    if (errorCode == MessagingErrorCode.Unregistered)
                    {
                        tokens[i].FcmToken = null;
                        tokens[i].LastFcmUpdate = DateTime.UtcNow;
                    }
                }
            }

            await _unitOfWork.Complete();
        }

        private static ClientTypeEnum[] GetClientTypes(string appType) => appType switch
        {
            "Player" => new[] { ClientTypeEnum.Player },
            "FacilityCaptain" => new[]
            {
                ClientTypeEnum.CaptainMobile,
                ClientTypeEnum.CaptainWeb,
                ClientTypeEnum.FacilityMobile,
                ClientTypeEnum.FacilityWeb
            },
            "Admin" => new[] { ClientTypeEnum.Admin },
            _ => Array.Empty<ClientTypeEnum>()
        };

        private void LogError(Exception ex)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILoggerService>();
            logger.LogError("Error In Firebase Service", ex);
        }
    }
}
