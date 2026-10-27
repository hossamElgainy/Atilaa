using Core.Abstraction;

namespace Core.Dtos
{
    public class GetCaptainBookingsDto:BaseEntityInt
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public int RemainingSessions { get; set; }
    }
}
