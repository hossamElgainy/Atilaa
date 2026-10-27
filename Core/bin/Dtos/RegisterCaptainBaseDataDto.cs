using Core.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class RegisterCaptainBaseDataDto
    {
        [Required(ErrorMessage = "The Name Is Required")]
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Whatsapp { get; set; }

        [Required(ErrorMessage = "The Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        public string Password { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string? TikTok { get; set; }
    }
}
