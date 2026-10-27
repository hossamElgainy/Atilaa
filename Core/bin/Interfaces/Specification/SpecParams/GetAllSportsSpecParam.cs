using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetAllSportsSpecParam:BasicPaginationParam
    {
        public string? Title { get; set; }
        public bool IsPopular { get; set; }
    }
}
