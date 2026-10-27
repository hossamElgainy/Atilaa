using Core.Abstraction;

namespace Core.Dtos
{
    public class GetDropInClassesDto:BaseEntityInt
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Captain { get; set; }
        public string CaptainImage { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
        public int TotalJoiners { get; set; }
        public bool Repeated { get; set; }
        public List<SessionJoinersListDto> Joiners { get; set; }
    }
}
