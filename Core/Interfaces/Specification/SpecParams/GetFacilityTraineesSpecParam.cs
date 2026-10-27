using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetFacilityTraineesSpecParam:BasicPaginationParam
    {
        public string? Name { get; set; }
        public int FacilityId { get; set; }
        public int BranchId { get; set; }
    }
}
