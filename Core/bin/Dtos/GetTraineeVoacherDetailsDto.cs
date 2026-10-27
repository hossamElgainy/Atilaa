namespace Core.Dtos
{
    public class GetTraineeVoacherDetailsDto
    {
        public int points { get; set; }
        public decimal EquevelantTo => points / (decimal)PointsPerPound;
        public int PointsPerBooking { get; set; }
        public int PointsPerAttendSession { get; set; }
        public int PointsPerDailyLogin { get; set; }
        public int PointsPerPound { get; set; }
    }
}
