namespace Core.Dtos
{
    public class GetNearestPlacesOnMapDto
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public bool IsFacility { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Distance { get; set; }
        public decimal Rate { get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
