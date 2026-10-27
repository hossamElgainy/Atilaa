using Core.Abstraction;

namespace Core.DomainModels
{
    public class FavouriteFacility : BaseEntityInt
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int BranchId { get; set; }
        public FacilityBranch Branch { get; set; }
    }

    


}
