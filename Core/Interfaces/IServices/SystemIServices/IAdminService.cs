using Core.Dtos;
using Core.Dtos.Account;

namespace Core.Interfaces.IServices.SystemIServices
{
    public interface IAdminService
    {
        Task<ServiceResponseDto<string>> RegisterAsync(RegisterAdminDto model);    
    }
}