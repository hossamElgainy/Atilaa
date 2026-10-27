using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Account
{
    public class EditProfileDto
    {
        [Required]
        public string Name { get; set; }
     
        [Required]
        public string Phone { get; set; }
        public string? WhatsApp { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int? CategoryId { get; set; }
        public int? LevelId { get; set; }
        public IFormFile? Image { get; set; }
    }
}