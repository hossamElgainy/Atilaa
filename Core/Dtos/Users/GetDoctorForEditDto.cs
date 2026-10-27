namespace Core.Dtos.Users
{
    public class GetDoctorForEditDto
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public bool IsPopular { get; set; }
        public string Biography { get; set; }
        public string FacebookUrl { get; set; }
        public string WhatsAppUrl { get; set; }
        public string TelegramUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}
