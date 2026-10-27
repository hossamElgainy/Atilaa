using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class EditTraineePersonalDataDto
    {
        public IFormFile? Image { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public GenderEnum? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Weight { get; set; }
        public int? Tall { get; set; }
    }
}
