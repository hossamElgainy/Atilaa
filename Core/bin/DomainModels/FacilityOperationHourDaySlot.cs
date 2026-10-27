using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class FacilityOperationHourDaySlot : BaseEntityInt
    {
        public int FacilityOperationHourId { get; set; }
        public FacilityOperationHour FacilityOperationHour { get; set; }
        public DayOfWeekEnum Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
    public class CaptainOperationHourDaySlot : BaseEntityInt
    {
        public int CaptainOperationHourId { get; set; }
        public CaptainOperationHour CaptainOperationHour { get; set; }
        public DayOfWeekEnum Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
