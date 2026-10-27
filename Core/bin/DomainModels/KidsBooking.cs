using Core.Abstraction;

namespace Core.DomainModels
{
    public class KidsBooking : BaseEntityInt
    {
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
