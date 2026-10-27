using Core.Abstraction;
using Core.Enums;

namespace Core.Dtos.Users
{
    public class GetAllAdminsDto:BaseEntityInt
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RolesEnum Role { get; set; }
        public string? Image { get; set; }
        public string? Code { get; set; }
        
        public bool LoggedIn { get; set; }
    }
}
