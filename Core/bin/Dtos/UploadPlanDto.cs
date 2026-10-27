using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class UploadPlanDto
    {
        public string Title { get; set; }
        public IFormFile File { get; set; }
        public int TraineeId { get; set; }
        public int? KidId { get; set; }
    }
}
