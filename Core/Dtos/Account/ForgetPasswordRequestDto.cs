using Core.Enums;

namespace Core.Dtos.Account
{
    public class ForgetPasswordRequestDto
    {
        public RolesEnum Role { get; set; }
        public string Email { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
    }
}