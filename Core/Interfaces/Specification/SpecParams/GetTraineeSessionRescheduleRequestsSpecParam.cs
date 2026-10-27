using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Enums;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetTraineeSessionRescheduleRequestsSpecParam:BasicPaginationParam
    {
        public BookingStatusEnum Status { get; set; }

    }
}
