using Core.Abstraction;

namespace Core.Dtos
{
    public class GetCaptainDetailsDto:BaseEntityInt
    {
        public string BackImage { get; set; }
        public string PersonalImage { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public int ReviewCount { get; set; }
        public int Experiance { get; set; }
        public int Trainees { get; set; }
        public string Speciality { get; set; }
        public string Description { get; set; }
        public bool IsFavourite { get; set; }
        public List<CommunityWorkDto> Community { get; set; }
        public ReviewsSammaryDto ReviewsSammary { get; set; }
        public ReviewCardDto? RecentReview { get; set; }
        public List<GetCaptainCertificationsDto> Certifications { get; set; }
    }

    public class GetCaptainCertificationsDto:BaseEntityInt
    {
        public string Image { get; set; }
    }
}
