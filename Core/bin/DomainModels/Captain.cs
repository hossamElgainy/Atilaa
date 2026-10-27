using Core.Abstraction;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.DomainModels
{
    public class Captain : BaseEntityInt
    {
        public string? WhatsApp { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string? Location { get; set; }
        public string? BackGroundImage { get; set; }
        public bool MustAcceptBooking { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string? TikTok { get; set; }
        public bool HaveFreeSession { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? SportId { get; set; }
        public Sport? Sport { get; set; }
        public ICollection<CaptainFacilities>? CaptainFacilities { get; set; } = new HashSet<CaptainFacilities>();
        public ICollection<CaptainOperationHour>? CaptainOperationHours { get; set; } = new HashSet<CaptainOperationHour>();
        public ICollection<BlockedTrainee>? BlockedTrainees { get; set; } = new HashSet<BlockedTrainee>();
        public ICollection<FavouriteCaptain>? FavouriteCaptains { get; set; } = new HashSet<FavouriteCaptain>();
        public ICollection<FacilityCaptainsOperationHour>? FacilityCaptainsOperationHours { get; set; } = new HashSet<FacilityCaptainsOperationHour>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<CaptainWork> Work { get; set; } = new HashSet<CaptainWork>();
        public ICollection<CaptainCertification> Certifications { get; set; } = new HashSet<CaptainCertification>();
        public ICollection<DropInClass> DropInClasses { get; set; } = new HashSet<DropInClass>();
        public ICollection<TrainingPlan> Plans { get; set; } = new HashSet<TrainingPlan>();
        public ICollection<KidsNote> KidsNotes { get; set; } = new HashSet<KidsNote>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}
