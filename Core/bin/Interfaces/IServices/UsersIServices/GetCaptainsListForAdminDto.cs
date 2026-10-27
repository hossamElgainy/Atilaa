using Core.Abstraction;

namespace Core.Interfaces.IServices.UsersIServices
{
    public class GetCaptainsListForAdminDto:BaseEntityInt
     {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Sport { get; set; }
        public decimal Rate { get; set; }
        public int PlayersCount { get; set; }

    
    }
}