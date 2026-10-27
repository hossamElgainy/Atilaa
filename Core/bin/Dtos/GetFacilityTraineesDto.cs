using Core.Abstraction;

namespace Core.Dtos
{
    public class GetFacilityTraineesDto:BaseEntityInt
    {
        public bool IsKid { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public int SessionsCount { get; set; }
        public string Diseases { get; set; }
        public DateTime Date { get; set; }
    }
}
