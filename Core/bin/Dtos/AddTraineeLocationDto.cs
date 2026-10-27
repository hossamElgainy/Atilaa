using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class AddTraineeLocationDto
    {
        [Required(ErrorMessage = "Location Type Is Required")]
        public LocationTypeEnum LocationType { get; set; }
        [Required(ErrorMessage = "Latitude Value Is Required")]
        public double Lat { get; set; }
        [Required(ErrorMessage = "Longitude Value Is Required")]
        public double Long { get; set; }
        [Required(ErrorMessage = "The Location Details Is Required")]
        public string Location { get; set; }
    }
}
