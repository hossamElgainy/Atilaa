using Core.Abstraction;

namespace Core.DomainModels
{
    public class KidsNote:BaseEntityInt
    {
        public string Note { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int? KidId { get; set; }
        public Kid? Kid { get; set; }
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}
