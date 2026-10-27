using Core.Abstraction;

namespace Core.DomainModels
{
    public class FacilitySports : BaseEntityInt
    {
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }

    


}
