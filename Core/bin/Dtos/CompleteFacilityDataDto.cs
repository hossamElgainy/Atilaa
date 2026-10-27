using Core.Abstraction;
using Core.DomainModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class CompleteFacilityDataDto
    {

        public int FacilityId { get; set; }
        [Required(ErrorMessage = "Sports Is Required")]
        public List<int> Sports { get; set; }
        [Required(ErrorMessage = "Captains Is Required")]
        public List<int> Captains { get; set; }
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
