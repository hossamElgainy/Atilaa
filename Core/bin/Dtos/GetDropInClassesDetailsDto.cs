using Core.Abstraction;
using Core.Interfaces.IServices.UsersIServices;

namespace Core.Dtos
{
    public class GetDropInClassesDetailsDto:BaseEntityInt
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Captain { get; set; }
        public string CaptainImage { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public bool Repeated { get; set; }
        public decimal Price { get; set; }
        public int TotalJoiners { get; set; }
        public List<SessionJoinersListDto> Joiners { get; set; }
        public List<CommunityWorkDto> Community { get; set; }
    }
}
