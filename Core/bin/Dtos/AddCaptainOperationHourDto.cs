using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos
{
    public class AddCaptainOperationHourDto
    {
        public int UserId { get; set; }
        public LevelsEnum Level { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public List<FacilityDayTimeSlotDto>? DaySlots { get; set; }

        public TargetAudienceEnum TargetAudience { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public SessionTypeEnum SessionType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int MaxPersonsInGroup { get; set; }
        public int PackageSessionsCount { get; set; }
    }
}
