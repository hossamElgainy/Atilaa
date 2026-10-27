using Core.Abstraction;

namespace Core.DomainModels
{
    public class FacilityCaptainsOperationHour : BaseEntityInt
    {

        public int FacilityOperationHourId { get; set; }
        public FacilityOperationHour FacilityOperationHour { get; set; }
        public int CaptainId { get; set; }
        public Captain Captain { get; set; }
    }

    


}
