using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class AddCaptainWorkDto
    {
        public IFormFile File { get; set; }
        public bool IsImage { get; set; }
    }
}
