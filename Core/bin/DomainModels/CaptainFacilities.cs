using Core.Abstraction;
using Core.Enums;

namespace Core.DomainModels
{
    public class CaptainFacilities : BaseEntityInt
    {
        //public LevelsEnum Level { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
        public int BranchId { get; set; }
        public FacilityBranch Branch { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    


}
