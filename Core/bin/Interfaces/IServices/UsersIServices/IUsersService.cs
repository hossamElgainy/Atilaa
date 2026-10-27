using Core.Dtos;
using Core.Dtos.Account;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IUsersService
    {
        Task<ServiceResponseDto<string>> Delete(int Id);
        Task<AuthModel> UpdateProfileImage(IFormFile Image,int UserId);
        Task<bool> CompletedData(int UserId);
    }
}
