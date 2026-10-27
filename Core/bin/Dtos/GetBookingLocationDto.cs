using Core.Abstraction;

namespace Core.Dtos
{
    public class GetBookingLocationDto
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Location { get; set; }
    }
}
