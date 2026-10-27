
using Core.DomaimModels;
using Core.Dtos;
using Core.Dtos.Account;
using Core.Enums;

namespace Core.Interfaces.IServices.SystemIServices
{
    public interface IAuthService
    {
        Task<AuthModel> LoginAsync(LoginDto model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        RefreshToken GenerateRefreshToken();
        Task<string> GenerateVerificationnCode(int userId, string userEmail);
        Task<ServiceResponseDto<VerificationCodeValidationResult>> ValidateVerificationCode(string email,RolesEnum role, string verificationCode);
        Task<ServiceResponseDto<string>> SendVerificationCode(string email, RolesEnum role, EmailEnum type);
        Task<ServiceResponseDto<string>> ResetPasswordAsync(ForgetPasswordRequestDto dto);

        Task<bool> EmailExist(string email,RolesEnum role, bool forAdd = true);
        Task<bool> PhoneExist(string phone,RolesEnum role, bool forAdd = true);
        Task<ServiceResponseDto<AuthModel>> VerifyUserAsync(ValidateVerificationCodeDto verifyDto);
        Task<ServiceResponseDto<string>?> ValidateUniqueContacts(string? email, string? phone,RolesEnum role);
        Task<ServiceResponseDto<string>> ChangePasswordAsync(int UserId, ChangePasswordDto dto);
    }

}