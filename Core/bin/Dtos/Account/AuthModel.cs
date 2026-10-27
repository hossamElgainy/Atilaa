using System.Text.Json.Serialization;

namespace Core.Dtos.Account
{
    public class AuthModel
    {
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? JwtToken { get; set; }
        public DateTime? ExpiresOn { get; set; }        
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}