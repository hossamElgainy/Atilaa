using Core.Abstraction;
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModels
{
    public class DropInClass : BaseEntityInt
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public List<DayOfWeekEnum> Days { get; set; }
        public TimeSpan StartAt { get; set; }
        public bool IsRepeated { get; set; }
        public int MaxJoinersCount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public HashSet<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
