namespace Core.Dtos
{
    public class GetCaptainsListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public string Academies { get; set; }
        public decimal Rate { get; set; }
        public double Distance { get; set; }
    }
}
