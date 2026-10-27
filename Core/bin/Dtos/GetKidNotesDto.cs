using Core.Abstraction;

namespace Core.Dtos
{
    public class GetKidNotesDto:BaseEntityInt
    {
        public string CaptainName { get; set; }
        public string CaptainImage { get; set; }
        public string CaptainSpeciality { get; set; }
        public string SpecialityImage { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

    }
}
