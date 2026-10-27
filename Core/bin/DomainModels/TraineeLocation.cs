using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class TraineeLocation:BaseEntityInt
    {
        public LocationTypeEnum LocationType { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Location { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
    }




}
