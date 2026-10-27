
using Core.Abstraction;
using Core.DomainModels;
using Core.Enums;

namespace Core.DomaimModels
{
    public class RefreshToken:BaseEntityInt
    {
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsExpired  => DateTime.UtcNow >= ExpiresOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsActive => RevokedOn == null && !IsExpired;
        public int UserId { get; set; }
        public User User { get; set; }
        public string? FcmToken { get; set; }           // FCM registration token (nullable)
        public DateTime? LastFcmUpdate { get; set; }
        public ClientTypeEnum ClientType { get; set; }
    }
}