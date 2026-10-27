using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos
{
    public class EditCaptainOperationHourDto
    {
        public int Id { get; set; }
        public int CaptainId { get; set; }
        public LevelsEnum Level { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public List<DayOfWeekEnum> Days { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public TargetAudienceEnum TargetAudience { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public SessionTypeEnum SessionType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int MaxPersonsInGroup { get; set; }
        public int PackageSessionsCount { get; set; }
    }
}
