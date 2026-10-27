namespace Core.Dtos
{
    public class GetKidOverViewDto
    {
        public List<KidProgressDto> Progress { get; set; }
        public List<KidSessionsForProfileDto> Sessions { get; set; }
    }

    public class KidSessionsForProfileDto
    {
        public int Id { get; set; }
        public string SessionTitle { get; set; }
        public string Name { get; set; }
        public int CaptainId { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }

    public class KidProgressDto
    {
        public string Sport { get; set; }
        public int Percentage { get; set; }
    }
}
