using Core.Abstraction;

namespace Core.DomainModels
{
    public class TraineeVoacher : BaseEntityInt
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public string Note { get; set; }
        public int Points { get; set; }
        public DateTime Date { get; set; }
    }
}
