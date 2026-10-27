using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class Session:BaseEntityInt
    {
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public string QRCode { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<SessionRescheduleRequest> RescheduleRequests { get; set; } = new HashSet<SessionRescheduleRequest>();

    }
    public class SessionRescheduleRequest:BaseEntityInt
    {
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public DateTime RequestedDate { get; set; }
        public BookingStatusEnum Status { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }

}
