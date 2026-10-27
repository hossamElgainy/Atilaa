namespace Core.Dtos
{
    public class ReviewCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Review { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
