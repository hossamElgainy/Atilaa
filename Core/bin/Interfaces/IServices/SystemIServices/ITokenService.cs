


using Core.DomainModels;
using Core.Enums;

namespace Core.Interfaces.IServices.SystemIServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user,RolesEnum? role);
        DateTime? ExtractValidToDateFromToken(string tokenString);
    }
}
