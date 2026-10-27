using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class AddAnnouncementDto
    {
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public bool Active { get; set; }
        public string? Url { get; set; }

    }
}
