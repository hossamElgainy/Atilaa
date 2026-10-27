using Core.Abstraction;
using Core.Dtos;
using Core.Enums;

namespace Core.DomainModels
{
    public class Trainee : BaseEntityInt
    {
        public GenderEnum? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Weight { get; set; }
        public int? Tall { get; set; }
        public string? Goal { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Points { get; set; }
        //public decimal Wallet { get; set; }
        public ICollection<View>? Views { get; set; } = new HashSet<View>();
        public ICollection<Booking>? Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<Kid>? Kids { get; set; } = new HashSet<Kid>();
        public ICollection<BlockedTrainee>? BlockedTrainees { get; set; } = new HashSet<BlockedTrainee>();
        public ICollection<FavouriteSport>? FavouriteSports { get; set; } = new HashSet<FavouriteSport>();
        public ICollection<FavouriteFacility>? FavouriteFacilities { get; set; } = new HashSet<FavouriteFacility>();
        public ICollection<FavouriteCaptain>? FavouriteCaptains { get; set; } = new HashSet<FavouriteCaptain>();
        public ICollection<TraineeLocation>? TraineeLocations { get; set; } = new HashSet<TraineeLocation>();
        public ICollection<Kid>? MyKids { get; set; } = new HashSet<Kid>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<TrainingPlan> Plans { get; set; } = new HashSet<TrainingPlan>();
        public ICollection<KidsNote> KidsNotes { get; set; } = new HashSet<KidsNote>();
        public ICollection<TraineeVoacher> TraineeVoacher { get; set; } = new HashSet<TraineeVoacher>();
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new HashSet<PaymentTransaction>();

    }
}
