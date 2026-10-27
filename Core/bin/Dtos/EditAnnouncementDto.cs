using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class EditAnnouncementDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public IFormFile? Image { get; set; }
        public bool? Active { get; set; }
        public string? Url { get; set; }

    }
}
