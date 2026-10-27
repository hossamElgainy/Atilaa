namespace Core.Dtos
{
    public class GetFacilitiesListDto
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public double Distance { get; set; }
        public double Rate { get; set; }
        public List<FacilityCaptainsDto> Captains { get; set; }
    }
}
