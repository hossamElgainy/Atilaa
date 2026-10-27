using Core.Abstraction;

namespace Core.DomainModels
{
    public class FavouriteCaptain : BaseEntityInt
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
    }

    


}
