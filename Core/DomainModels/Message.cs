using Core.Enums;

namespace Core.DomainModels
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.Sent;
        public DateTime? ReadAt { get; set; }

        public bool IsRead => ReadAt.HasValue;
    }
}
