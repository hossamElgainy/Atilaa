using Core.DomainModels;
using Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Account
{
    public class RegisterStudentDto
    {
        [Required]
        public string Name { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        //[Required]
        public string? Phone { get; set; }
        //[Required]
        public string? WhatsApp { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int LevelId { get; set; }
        public IFormFile? Image { get; set; }
    }
}