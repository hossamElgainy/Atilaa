using Core.Abstraction;
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModels
{
    public class FacilityOperationHour : BaseEntityInt
    {
        public string Title { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int BranchId { get; set; }
        public FacilityBranch Branch { get; set; }
        public LevelsEnum Level { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public List<DayOfWeekEnum> days { get; set; }
        public SessionLocationEnum SessionLocation { get; set; } = SessionLocationEnum.OnGround;
        public bool WithCaptain { get; set; } // in case of Gym
        public string? Goal { get; set; } // in case of Gym
        public ExpirationOnEnum ExprirationOn { get; set; }// in case of Gym
        public TargetAudienceEnum TargetAudience { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public SessionTypeEnum SessionType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int MaxPersonsInGroup { get; set; }
        public int PackageSessionsCount { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<FacilityOperationHourDaySlot> DaySlots { get; set; } = new HashSet<FacilityOperationHourDaySlot>();
        public ICollection<FacilityCaptainsOperationHour>? FacilityCaptainsOperationHours { get; set; } = new HashSet<FacilityCaptainsOperationHour>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();


    }
}
