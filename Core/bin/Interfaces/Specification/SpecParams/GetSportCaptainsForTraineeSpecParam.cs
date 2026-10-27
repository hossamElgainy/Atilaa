using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetSportCaptainsForTraineeSpecParam: BasicPaginationParam
    {
        public string? Name { get; set; }
        [Required]
        public int SportId { get; set; }
        public TargetAudienceEnum? TargetAudience { get; set; }

    }
}
