namespace Core.Dtos
{
    public class GetFacilityUpCommingSessionsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Sport { get; set; }
        public int RemainingSessions { get; set; }
    }
    public class GetSessionRescheduleRequessDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime OldDate { get; set; }
        public DateTime NewDate { get; set; }
        public string Status { get; set; }
    }
    public class GetHomeSummaryDataDto
    {
        public GetFacilityUpCommingSessionsDto? UpCommingSession { get; set; }
        public GetTraineeVoacherDto? Voacher { get; set; }
        public int? Progress { get; set; }
    }

    public class GetTraineeVoacherDto
    {
        public int Points { get; set; }
        public decimal EquivalentTo { get; set; }
    }
}
