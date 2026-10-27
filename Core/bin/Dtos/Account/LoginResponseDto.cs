namespace Core.Dtos.Account
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}