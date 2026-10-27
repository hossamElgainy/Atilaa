using Core.Enums;

namespace Core.Dtos
{
    public class GetCaptainTrainingPlacesDto
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string Title { get; set; }
        public bool IsFacility { get; set; }
       
    }
    public class GetFacilityTrainingHoursForTraineeDto
    {
        public int FacilityId { get; set; }
        public int BranchId { get; set; }
        public int CaptainId { get; set; }
        public SessionTypeEnum SessionType { get; set; }
        public BookingTypeEnum BookingType { get; set; }
       
    }
}
