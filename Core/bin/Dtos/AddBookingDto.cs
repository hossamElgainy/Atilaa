using Core.Enums;

namespace Core.Dtos
{
    public class AddBookingDto
    {
        public BookingResourceType Resource { get; set; }
        public int? FacilityTimeSlotId { get; set; }
        public int? CaptainTimeSlotId { get; set; }
        public int? DropInClassId { get; set; }
        public List<int>? KidIds { get; set; }
    }
}
