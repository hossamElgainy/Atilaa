namespace Core.Dtos
{
    public class GetTrainingPlansForTraineeDto
    {
        public int TraineeId { get; set; }
        public int CaptainId { get; set; }
        public string CaptainName { get; set; }
        public string SportName { get; set; }
        public string CaptainImage { get; set; }
    }
}
