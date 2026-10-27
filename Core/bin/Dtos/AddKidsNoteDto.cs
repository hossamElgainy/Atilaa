namespace Core.Dtos
{
    public class AddKidsNoteDto
    {
        public string Note { get; set; }
        public int TraineeId { get; set; }
        public int? KidId { get; set; }
    }
}
