using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetFacilitySessionsSpecParam:BasicPaginationParam
    {
        public int FacilityId { get; set; }
        public int BranchId { get; set; }
        public bool Previos { get; set; }
    }
    public class GetCaptainSessionsSpecParam:BasicPaginationParam
    {
        public bool Previos { get; set; }
    }
}
