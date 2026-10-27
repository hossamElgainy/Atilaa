using Core.Enums;

namespace Core.Dtos
{
    public class ValidateVerificationCodeDto
    {
        public string Email { get; set; }
        public RolesEnum Role { get; set; }
        public string VerificationCode { get; set; }
    }
}