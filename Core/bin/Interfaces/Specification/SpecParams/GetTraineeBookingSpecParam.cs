using AshalLms.Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetTraineeBookingSpecParam:BasicPaginationParam
    {
        public bool Active { get; set; } = true;
    }
}
