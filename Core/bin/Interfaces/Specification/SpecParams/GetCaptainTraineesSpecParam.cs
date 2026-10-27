using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetCaptainTraineesSpecParam:BasicPaginationParam
    {
        public string? Name { get; set; }
    }
}
