namespace Core.Dtos
{
    public class GetTopThreeOnLeaderBoardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int TotalPoints { get; set; }
        public bool You { get; set; }
    }
}
