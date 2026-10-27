using Core.DomainModels;
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos
{
    public class EditGymOperationHourDto
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int SportId { get; set; }
        public int? AgeFrom { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public TargetAudienceEnum TargetAudience { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public ExpirationOnEnum ExprirationOn { get; set; } 
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int PackageSessionsCount { get; set; }
        public string? Goal { get; set; }
    }
}
