using Core.Abstraction;

namespace Core.DomainModels
{
    public class UserRequest:BaseEntityInt
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int EntityId { get; set; }
        public RequestTypeEnum RequestType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool HasAccepted { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
