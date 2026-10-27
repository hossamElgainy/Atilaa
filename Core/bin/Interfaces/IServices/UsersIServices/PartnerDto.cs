namespace Core.Interfaces.IServices.UsersIServices
{
    public class PartnerDto
    {
        public int Id { get; set; }
        public string ProductImage { get; set; } = string.Empty;
        public string PartnerLogo { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ExternalLink { get; set; } = string.Empty;
        public string PromoCode { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
