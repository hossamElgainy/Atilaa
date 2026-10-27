using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class BlockedTrainee : BaseEntityInt
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public int? FacilityId { get; set; }
        public Facility? Facility { get; set; }
    }

    public class SystemActivite : BaseEntityInt
    {
        public SystemActivityEnum Type { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public User User { get; set; }
        public int? EntityId { get; set; }
        public string? EntityType { get; set; }
    }

   
}
