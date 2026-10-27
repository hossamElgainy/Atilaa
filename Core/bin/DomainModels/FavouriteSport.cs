using Core.Abstraction;

namespace Core.DomainModels
{
    public class FavouriteSport : BaseEntityInt
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }

    


}
