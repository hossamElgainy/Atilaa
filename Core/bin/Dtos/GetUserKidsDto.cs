namespace Core.Dtos
{
    public class GetUserKidsDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public int NoOfSessions { get; set; }
        public string? Diseases { get; set; }
    }
}
