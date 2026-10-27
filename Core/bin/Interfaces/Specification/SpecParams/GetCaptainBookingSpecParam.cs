using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Enums;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetCaptainBookingSpecParam:BasicPaginationParam
    {
        public bool Active { get; set; }
        public BookingStatusEnum? Status { get; set; }
        public bool Session { get; set; }
    }
}
