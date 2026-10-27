using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Enums;

namespace Core.Interfaces.Specification.SpecParams
{
    public class GetTraineeFavouritesSpecParam:BasicPaginationParam
    {
        public TraineeFavouriteTypeEnum type { get; set; }
        public string? Title { get; set; }
    }
}
