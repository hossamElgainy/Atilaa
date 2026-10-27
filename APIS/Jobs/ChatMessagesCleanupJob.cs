using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace APIS.Jobs
{
    public class ChatMessagesCleanupJob
    {
        private readonly AppDbContext _db;

        public ChatMessagesCleanupJob(AppDbContext db)
        {
            _db = db;
        }

        public async Task DeleteMessagesOlderThanThreeMonthsAsync()
        {
            var cutoff = DateTime.UtcNow.AddMonths(-3);
            var oldMessages = await _db.Messages
                .Where(m => m.Timestamp < cutoff)
                .ToListAsync();

            if (!oldMessages.Any())
                return;

            _db.Messages.RemoveRange(oldMessages);
            await _db.SaveChangesAsync();
        }
    }
}
