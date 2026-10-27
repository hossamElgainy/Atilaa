using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetHomeFilterForTraineeSpecParam: BasicPaginationParam
    {
        public string Name { get; set; }
    }
}
