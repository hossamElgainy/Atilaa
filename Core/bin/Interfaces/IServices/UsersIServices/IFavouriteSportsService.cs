using Core.DomainModels;
using Core.Dtos;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IFavouriteSportsService
    {
        Task<ServiceResponseDto<string>> Add(int sportId, int userId);
        Task<ServiceResponseDto<string>> Delete(int SportId, int userId);
    }
}
