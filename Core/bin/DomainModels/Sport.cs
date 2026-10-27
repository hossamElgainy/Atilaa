using Core.Abstraction;
using System.Numerics;

namespace Core.DomainModels
{
    public class Sport : BaseEntityInt
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string? Icon { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPopular { get; set; }
        public ICollection<Captain>? Captains { get; set; } = new HashSet<Captain>();
        public ICollection<FacilitySports>? FacilitySports { get; set; } = new HashSet<FacilitySports>();
        public ICollection<FavouriteSport>? FavouriteSports { get; set; } = new HashSet<FavouriteSport>();
        public ICollection<FacilityOperationHour>? FacilityOperationHours { get; set; } = new HashSet<FacilityOperationHour>();

    }




}
