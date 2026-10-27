using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Jobs
{
    public class NotificationsCleanupJob
    {
        private readonly AppDbContext _db;

        public NotificationsCleanupJob(AppDbContext db)
        {
            _db = db;
        }

        public async Task DeleteNotificationByIdAsync(int notificationId)
        {
            var notification = await _db.NotificationModels
                .FirstOrDefaultAsync(n => n.Id == notificationId);
            if (notification == null)
                return;

            _db.NotificationModels.Remove(notification);
            await _db.SaveChangesAsync();
        }
    }
}
