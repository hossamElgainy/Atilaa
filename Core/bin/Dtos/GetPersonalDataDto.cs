using Core.Enums;

namespace Core.Dtos
{
    public class GetPersonalDataDto
    {
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
