using Core.Abstraction;
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModels
{
    public class CaptainOperationHour : BaseEntityInt
    {
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public LevelsEnum Level { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public List<DayOfWeekEnum> Days { get; set; }
        public TargetAudienceEnum TargetAudience { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public SessionTypeEnum SessionType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int MaxPersonsInGroup { get; set; }
        public int PackageSessionsCount { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CaptainOperationHourDaySlot> DaySlots { get; set; } = new HashSet<CaptainOperationHourDaySlot>();

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }




}
