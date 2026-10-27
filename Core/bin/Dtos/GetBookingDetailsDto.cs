using Core.Abstraction;

namespace Core.Dtos
{
    public class GetBookingDetailsDto:BaseEntityInt
    {
        public string Sport { get; set; }
        public TimeSpan RemainingTime { get; set; }
        public DateTime Date { get; set; }
        public UserSimpleDataDto Captain { get; set; }
        public GetBookingLocationDto Location { get; set; }
        public UserSimpleDataDto Trainee { get; set; }
        public List<UserSimpleDataDto> Kids { get; set; }
        public bool IsKidsBooking { get; set; }
        public List<GetBookingSessionsDto> Sessions { get; set; }
    }
}
