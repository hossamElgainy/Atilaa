using Core.Abstraction;

namespace Core.Dtos
{
    public class GetCaptainScheduleDto:BaseEntityInt
    {
        public string Level { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public List<string> Days { get; set; }
        public List<GetFacilityDayTimeSlotDto>? DaySlots { get; set; }
        public string TargetAudience { get; set; }
        public string BookingType { get; set; }
        public string SessionType { get; set; }
        public decimal Price { get; set; }
        public int MaxPersonsInGroup { get; set; }
        public int Capacity { get; set; }
        public int PackageSessionsCount { get; set; }
    }
    public class GetCaptainScheduleResponseDto
    {
        public ScheduleGroupDto Session { get; set; } = new();
        public ScheduleGroupDto Package { get; set; } = new();
    }

    public class ScheduleGroupDto
    {
        public decimal? Price { get; set; }          // Min price (nullable in case no items)
        public List<GetCaptainScheduleDto> TimesList { get; set; } = new();
    }
}
