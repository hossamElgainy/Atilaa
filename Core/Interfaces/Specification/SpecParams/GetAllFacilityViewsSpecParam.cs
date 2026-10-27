using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetAllFacilityViewsSpecParam:BasicPaginationParam
    {
        public int FaclilityId { get; set; }
    }
}
