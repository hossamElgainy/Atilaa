using Core.DomainModels;
using Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class RegisterKidDto        
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="The Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date Of Birth Is Required")]
        public DateTime DateOfBirth { get; set; }
        
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "The Gender Is Required")]
        public GenderEnum Gender { get; set; }
        public string? Phone { get; set; }

        public string? Email { get; set; }
        public string? Diseases { get; set; }

    }
}
