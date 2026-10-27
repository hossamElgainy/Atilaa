using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string PhoneOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public string? FireBaseToken { get; set; }
        [Required]
        public RolesEnum Role { get; set; }
    }
}