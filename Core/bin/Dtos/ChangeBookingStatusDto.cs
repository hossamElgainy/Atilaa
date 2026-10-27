using Core.Enums;

namespace Core.Dtos
{
    public class ChangeBookingStatusDto
    {
        public int Id { get; set; }
        public BookingStatusEnum Status { get; set; }
    }
}
