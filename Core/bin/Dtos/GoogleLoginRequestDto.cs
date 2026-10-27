using Core.Enums;

namespace Core.Dtos
{
    public class GoogleLoginRequestDto
    {
        public string IdToken { get; set; }
        public RolesEnum Role { get; set; }
    }
}