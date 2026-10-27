using Core.DomainModels;
using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class AddOrEditSport
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? Icon { get; set; }
        public bool IsPopular { get; set; }

    }
   
}
