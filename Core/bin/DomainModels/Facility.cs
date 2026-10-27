using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class Facility : BaseEntityInt
    {
        public string Title { get; set; }
        public FacilityEnum FacilityType { get; set; }
        public string? WhatsApp { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string? TikTok { get; set; }
        public string? Logo { get; set; }
        public string? BackGroundImage { get; set; }
        public bool MustAcceptBooking { get; set; }
        public bool HaveFreeSession { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<BlockedTrainee>? BlockedTrainees { get; set; } = new HashSet<BlockedTrainee>();
        public ICollection<View> Views { get; set; } = new HashSet<View>();
        public ICollection<CaptainFacilities> CaptainFacilities { get; set; } = new HashSet<CaptainFacilities>();
        public ICollection<FacilitySports> FacilitySports { get; set; } = new HashSet<FacilitySports>();
        public ICollection<FacilityOperationHour> FacilityOperationHours { get; set; } = new HashSet<FacilityOperationHour>();
        public ICollection<FavouriteFacility> FavouriteFacilities { get; set; } = new HashSet<FavouriteFacility>();
        public ICollection<FacilityBranch> Branches { get; set; } = new HashSet<FacilityBranch>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<FacilityWork> Works { get; set; } = new HashSet<FacilityWork>();

    }
}
