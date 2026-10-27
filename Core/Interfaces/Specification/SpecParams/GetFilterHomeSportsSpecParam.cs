using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetFilterHomeSportsSpecParam:BasicPaginationParam
    {
        public string? Title { get; set; }
    }
}
