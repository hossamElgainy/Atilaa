using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class Kid : BaseEntityInt
    {
        public GenderEnum? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Diseases { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int ParentId { get; set; }
        public Trainee Parent { get; set; }

        public ICollection<KidsBooking> KidsBookings { get; set; } = new HashSet<KidsBooking>();
        public ICollection<TrainingPlan> Plans { get; set; } = new HashSet<TrainingPlan>();
        public ICollection<KidsNote> KidsNotes { get; set; } = new HashSet<KidsNote>();

    }




}
