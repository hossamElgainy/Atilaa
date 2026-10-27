using Core.Dtos;
using Core.Dtos.Account;

namespace Core.Interfaces.IServices.SystemIServices
{
    public interface IExternalLoginService
    {
        Task<ServiceResponseDto<AuthModel>> LoginWithGoogleAsync(GoogleLoginRequestDto loginDto);
        Task<ServiceResponseDto<AuthModel>> LoginWithAppleAsync(AppleLoginRequestDto loginDto);
    }
}