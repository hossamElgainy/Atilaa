using Core.Abstraction;

namespace Core.DomainModels
{
    public class FacilityWork:BaseEntityInt
    {
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public string Url { get; set; }
        public bool Image { get; set; }
    }
}
