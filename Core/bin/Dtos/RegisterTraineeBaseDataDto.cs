using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class RegisterTraineeBaseDataDto
    {
        [Required(ErrorMessage = "The Name Is Required")]
        public string Name { get; set; }
        public string? Phone { get; set; }
        [Required(ErrorMessage = "The Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        public string Password { get; set; }
    }
    
}
