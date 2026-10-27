using Core.Abstraction;

namespace Core.DomainModels
{
    public class FacilityBranch : BaseEntityInt
    {
        public string Title { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string? Location { get; set; }
        public string? Phone { get; set; }
        public List<string>? Photos { get; set; }
        public List<string>? Certificates { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public ICollection<CaptainFacilities>? CaptainFacilities { get; set; } = new HashSet<CaptainFacilities>();
        public ICollection<FacilityOperationHour>? FacilityOperationHours { get; set; } = new HashSet<FacilityOperationHour>();
        public ICollection<View>? Views { get; set; } = new HashSet<View>();
        public ICollection<FavouriteFacility> FavouriteFacilities { get; set; } = new HashSet<FavouriteFacility>();


    }



}
