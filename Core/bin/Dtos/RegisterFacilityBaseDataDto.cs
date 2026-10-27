using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class RegisterFacilityBaseDataDto
    {
        [Required(ErrorMessage = "The Title Is Required")]
        public string Title { get; set; }
        public string? Phone { get; set; }
        public string? Whatsapp { get; set; }
        [Required(ErrorMessage = "The Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        public string Password { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string? TikTok { get; set; }
        public FacilityEnum Type { get; set; }
    }
}
