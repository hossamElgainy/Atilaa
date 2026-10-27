using Core.Abstraction;

namespace Core.Dtos
{
    public class GetFacilityDetailsDto:BaseEntityInt
    {
        public int BranchId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal Rate { get; set; }
        public int ReviewsCount { get; set; }
        public string ProfileImage { get; set; }
        public string BackGroundImage { get; set; }
        public string Desc { get; set; }
        public bool IsFavourite { get; set; }
        public List<CommunityWorkDto> Community { get; set; }
        public List<GetAllSportsDto> Sports { get; set; }
        public List<GetCaptainsListDto> Captains { get; set; }

    }
}
