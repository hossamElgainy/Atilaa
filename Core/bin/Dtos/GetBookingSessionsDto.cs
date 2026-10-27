using Core.Abstraction;

namespace Core.Dtos
{
    public class GetBookingSessionsDto:BaseEntityInt
    {
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
    }
}
