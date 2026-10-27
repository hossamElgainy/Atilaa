using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos
{
    public class AddFacilityOperationHourDto
    {
        public int FacilityId { get; set; }
        public int? BranchId { get; set; }
        public int SportId { get; set; }
        public string Title { get; set; }
        public LevelsEnum Level { get; set; }
        public SessionLocationEnum SessionLocation { get; set; } = SessionLocationEnum.OnGround;
        public SessionTypeEnum SessionType { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public TargetAudienceEnum TargetAudience { get; set; }

        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }

        public List<FacilityDayTimeSlotDto>? DaySlots { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int MaxPersonsInGroup { get; set; }
        public int PackageSessionsCount { get; set; }
    }

    public class FacilityDayTimeSlotDto
    {
        public DayOfWeekEnum Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
    public class GetFacilityDayTimeSlotDto
    {
        public string Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
