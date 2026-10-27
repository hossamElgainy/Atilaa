using Core.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Users
{
    public class AddOrEditAdminDto
    {
        public int? Id { get; set; }

        public string? Phone { get; set; }
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        public IFormFile? Image { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public bool IsPopular { get; set; }
        public string Biography { get; set; }
        public string? FacebookUrl { get; set; }
        public string? WhatsAppUrl { get; set; }
        public string? TelegramUrl { get; set; }
        public string? InstagramUrl { get; set; }
    }   
}
