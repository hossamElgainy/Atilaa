namespace Core.Dtos
{
    public class MobileFacilityMobileHomeStatisticsDto
    {
        public FacilityMobileHomeCaptainStats Captains { get; set; }
        public FacilityMobileHomeTraineeStats Trainees { get; set; }
        public FacilityMobileHomeViewStats Views { get; set; }
    }

    public class FacilityMobileHomeCaptainStats
    {
        public int CurrentCount { get; set; }
        public double ChangePercentage { get; set; }
    }

    public class FacilityMobileHomeTraineeStats
    {
        public int CurrentCount { get; set; }
        public double ChangePercentage { get; set; }
    }

    public class FacilityMobileHomeViewStats
    {
        public int CurrentCount { get; set; }
        public double ChangePercentage { get; set; }
    }
}
