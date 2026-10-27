using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Enums;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetSportFacilitiesForTraineeSpecParam: BasicPaginationParam
    {
        public int SportId { get; set; }
        public string? Name { get; set; }
        public TargetAudienceEnum? TargetAudience { get; set; }
    }
}
