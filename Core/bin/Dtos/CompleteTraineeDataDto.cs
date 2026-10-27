using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class CompleteTraineeDataDto
    {
        public int UserId { get; set; }
        public GenderEnum? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Weight { get; set; }
        public int? Tall { get; set; }
        public string? Goal { get; set; }
        public List<RegisterKidDto>? Kids { get; set; }
        public List<int>? Sports { get; set; }
        public List<AddTraineeLocationDto>? Location { get; set; }
    }
}
