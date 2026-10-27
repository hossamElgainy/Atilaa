namespace Core.Dtos
{
    public class GetAllAnnounceMentsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }
    }
}
