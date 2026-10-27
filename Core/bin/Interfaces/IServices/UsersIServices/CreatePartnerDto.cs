using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.IServices.UsersIServices
{
    // Core/Dtos/Partner/CreatePartnerDto.cs  (for create/update with file uploads)
    public class CreatePartnerDto
    {
        public IFormFile? ProductImageFile { get; set; }   // Optional on update
        public IFormFile? PartnerLogoFile { get; set; }    // Optional on update
        public string ProductName { get; set; } = string.Empty;
        public string ExternalLink { get; set; } = string.Empty;
        public string PromoCode { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
