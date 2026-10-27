using Core.Abstraction;

namespace Core.Dtos
{
    public class GetTraineeBookingsDto:BaseEntityInt
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string specialty { get; set; }
        public DateTime Date { get; set; }
        public int RemainingSessions { get; set; }
        public bool IsSession { get; set; }
    }
}
