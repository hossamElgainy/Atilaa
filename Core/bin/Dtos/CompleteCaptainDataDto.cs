using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class CompleteCaptainDataDto
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Sports Is Required")]
        public int SportId { get; set; }
        [Required(ErrorMessage = "Profile Image Is Required")]
        public IFormFile ProfileImage { get; set; }
        public IFormFile? BackGroundImage { get; set; }
        public List<IFormFile>? Certificates { get; set; }
        public List<IFormFile>? TrainingImages { get; set; }

        [Required(ErrorMessage = "Latitude Value Is Required")]
        public double Lat { get; set; }
        [Required(ErrorMessage = "Longitude Value Is Required")]
        public double Long { get; set; }
        [Required(ErrorMessage = "The Location Details Is Required")]
        public string Location { get; set; }
    }
}
