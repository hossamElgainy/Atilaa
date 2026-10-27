using Core.DomainModels;
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos
{
    public class AddGymOperationHourDto
    {
        public int FacilityId { get; set; }
        public int? BranchId { get; set; }
        public int SportId { get; set; }
        public int? AgeFrom { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public TargetAudienceEnum TargetAudience { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public ExpirationOnEnum ExprirationOn { get; set; }
        public bool WithCaptain { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int PackageSessionsCount { get; set; }
        public string? Goal { get; set; }
    }
}
