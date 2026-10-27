using Core.Abstraction;

namespace Core.Dtos
{
    public class GetTraineeBookingRequestsDto:BaseEntityInt
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
