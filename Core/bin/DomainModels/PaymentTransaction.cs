using Core.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModels
{
    public class PaymentTransaction : BaseEntityInt
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public PaymentMethodEnum Method { get; set; }
        public TransactionStatusEnum Status { get; set; } // Pending, Paid, Failed, Refunded
        public string? PaymobOrderId { get; set; }
        public string? PaymobTransactionId { get; set; }
        public string? PaymobHmac { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}
