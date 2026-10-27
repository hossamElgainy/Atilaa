using Core.Dtos;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IFavouriteCaptainsService
    {
        Task<ServiceResponseDto<string>> Add(int captainId, int userId);
        Task<ServiceResponseDto<string>> Delete(int captainId, int userId);
    }
}
