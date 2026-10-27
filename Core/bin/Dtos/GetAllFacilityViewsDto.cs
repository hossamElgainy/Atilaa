using Core.Abstraction;

namespace Core.Dtos
{
    public class GetAllFacilityViewsDto:BaseEntityInt
    {
        public int TotalViews { get; set; }
        public int TotalBookings { get; set; }
        public List<ViewsListDto> Views { get; set; }
    }
}
