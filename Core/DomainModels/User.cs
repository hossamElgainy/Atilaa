using Core.Abstraction;
using Core.DomaimModels;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class User:BaseEntityInt
    {

        public string? Phone { get; set; }
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }
        public string? Email { get; set; }               
        public string? Password { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public RolesEnum Role { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    
        public ICollection<Message> SendedMessages { get; set; } = new HashSet<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new HashSet<Message>();
    }
}
