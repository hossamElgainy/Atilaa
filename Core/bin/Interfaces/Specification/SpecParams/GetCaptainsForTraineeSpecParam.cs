using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Enums;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetCaptainsForTraineeSpecParam: BasicPaginationParam
    {
        public string? Name { get; set; }
        public List<int>? SportIds { get; set; }
        public SessionTypeEnum? SessionType { get; set; }
        public LevelsEnum? Level { get; set; }
        public TargetAudienceEnum? TargetAudience { get; set; }
        public decimal? PriceRangeFrom { get; set; }
        public decimal? PriceRangeTo { get; set; }
        public decimal? AgeRangeFrom { get; set; }
        public decimal? AgeRangeTo { get; set; }
    }
    public class GetCaptainsForAdminSpecParam: BasicPaginationParam
    {
        public string? Name { get; set; }
        public CaptainsFilterEnum Filter { get; set; }

    }

    public enum CaptainsFilterEnum
    {
        All=1,
        TopReate = 2,
        AllSubscription= 3,
        AllRevenues= 4,
    }

    public class GetFacilityCaptainsSpecParam: BasicPaginationParam
    {
        public int FacilityId { get; set; }
        public int BranchId { get; set; }
    }
}
