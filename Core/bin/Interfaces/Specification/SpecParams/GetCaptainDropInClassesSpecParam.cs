using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetCaptainDropInClassesSpecParam:BasicPaginationParam
    {
        public string? Title { get; set; }
    }
}
