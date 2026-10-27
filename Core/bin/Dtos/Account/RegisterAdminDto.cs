using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Account
{
    public class RegisterAdminDto
    {
        [Required]
        public string Name { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        //[Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}