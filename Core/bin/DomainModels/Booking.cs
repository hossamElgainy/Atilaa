using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class Booking : BaseEntityInt
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public DateTime BookedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public BookingStatusEnum Status { get; set; }
        public BookingResourceType Resource { get; set; }
        public int? FacilityTimeSlotId { get; set; }
        public FacilityOperationHour? FacilityTimeSlot { get; set; }
        public int? CaptainTimeSlotId { get; set; }
        public CaptainOperationHour? CaptainTimeSlot { get; set; }
        public int? DropInClassId { get; set; }
        public DropInClass? DropInClass { get; set; }

        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public int TotalSessions { get; set; }
        public int CompletedSessions { get; set; }
        public BookingTypeEnum Type { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public string QrCode { get; set; }
        public bool IsScanned { get; set; }
        public ICollection<KidsBooking> KidsBookings { get; set; } = new HashSet<KidsBooking>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new HashSet<PaymentTransaction>();
    }
}
