namespace Core.Dtos
{
    public class GetTrainingPlansForKidDto
    {
        public int KidId { get; set; }
        public int CaptainId { get; set; }
        public string Sport { get; set; }
        public string Logo { get; set; }
        public string Captain { get; set; }
        public string Level { get; set; }
        public DateTime? NextSession { get; set; }
        public double Percentage { get; set; }
    }
}
