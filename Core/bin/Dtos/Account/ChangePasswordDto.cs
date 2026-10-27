using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Account
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Old password is required.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "New password is required.")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword {get; set;}
    }
}