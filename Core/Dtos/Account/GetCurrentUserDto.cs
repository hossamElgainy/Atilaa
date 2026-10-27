using Core.DomainModels;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Account
{
    public class GetCurrentUserDto
    {
        public string Phone { get; set; }
        public string WhatsApp { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
        public int? LevelId { get; set; }
    }
}