using Application.Services.SystemServices;
using AshalLms.Core.DomainModels.UsersModels;
using Core.DomaimModels;
using Core.DomainModels;
using Core.Dtos;
using Core.Dtos.Account;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Core.Interfaces.Specification;
using Core.Interfaces.Specifications;
using Infrastructure.Data.Specifications;
using Infrastructure.Data.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Numerics;
using System.Security.AccessControl;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace Application.Services.UsersServices
{
    public class AuthService(IUnitOfWork _uow, ITokenService _tokenService, IPasswordHasher _hasher, IEmailService _email) : IAuthService
    {
        public async Task<AuthModel> LoginAsync(LoginDto model)
        {
            var authModel = new AuthModel();

            var user = await _uow.Repository<User>().GetByPropAsync(new GetUserAccountsSpec(model.PhoneOrEmail.ToLower(),model.Role));
            if (user is null)
            {
                authModel.Message = "Invalid email or password. Please check your credentials and try again.";
                return authModel;
            }
            var validpass = _hasher.VerifyPassword(user?.Password, model.Password);
            if (!validpass)
            {
                authModel.Message = "Invalid email or password. Please check your credentials and try again.";
                return authModel;
            }
            var jwtSecurityToken = await _tokenService.CreateToken(user,model.Role);

            authModel.IsAuthenticated = true;
            authModel.JwtToken = jwtSecurityToken;
            authModel.ExpiresOn = _tokenService.ExtractValidToDateFromToken(jwtSecurityToken);

            var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
            var hasRefreshTokenChanges = false;

            if (activeRefreshToken is null)
            {
                activeRefreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(activeRefreshToken);
                hasRefreshTokenChanges = true;
            }

            if (!string.IsNullOrWhiteSpace(model.FireBaseToken))
            {
                activeRefreshToken.FcmToken = model.FireBaseToken.Trim();
                activeRefreshToken.LastFcmUpdate = DateTime.UtcNow;
                activeRefreshToken.ClientType = GetClientType(model.Role);
                hasRefreshTokenChanges = true;
            }

            authModel.RefreshToken = activeRefreshToken.Token;
            authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn.ToLocalTime();

            if (hasRefreshTokenChanges)
                await _uow.Complete();

            return authModel;
        }

        private static ClientTypeEnum GetClientType(RolesEnum role) => role switch
        {
            RolesEnum.Trainee => ClientTypeEnum.Player,
            RolesEnum.Captain => ClientTypeEnum.CaptainMobile,
            RolesEnum.Facility => ClientTypeEnum.FacilityMobile,
            RolesEnum.Admin or RolesEnum.Kid => ClientTypeEnum.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Unsupported user role.")
        };

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();

            var user = await _uow.Repository<User>().GetByPropAsync(new GetUserRefreshTokensSpecification(token));

            if (user == null)
            {
                authModel.Message = "Invalid token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authModel.Message = "Inactive token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            newRefreshToken.FcmToken = refreshToken.FcmToken;
            newRefreshToken.LastFcmUpdate = refreshToken.LastFcmUpdate;
            newRefreshToken.ClientType = refreshToken.ClientType;
            user.RefreshTokens.Add(newRefreshToken);
            await _uow.Complete();

            var jwtToken = await _tokenService.CreateToken(user,user.Role);
            authModel.IsAuthenticated = true;
            authModel.JwtToken = jwtToken;
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.ExpiresOn = _tokenService.ExtractValidToDateFromToken(jwtToken)?.ToLocalTime();
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn.ToLocalTime();

            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _uow.Repository<User>().GetByPropAsync(new GetUserRefreshTokensSpecification(token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _uow.Complete();

            return true;
        }

        public async Task<string> GenerateVerificationnCode(int userId, string userEmail)
        {
            try
            {
                Random generator = new Random();
                string code = generator.Next(0, 1000000).ToString("D6");

                // insert the code to the database
                var validationCode = new ValidationCode()
                {
                    UserId = userId,
                    Code = code,
                    GeneratedDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddMinutes(10)
                };
                await _uow.Repository<ValidationCode>().AddAsync(validationCode);
                await _uow.Complete();
                return code;
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return ex.Message;
            }
        }

        public RefreshToken GenerateRefreshToken()
        {
            var randomNumber = RandomNumberGenerator.GetBytes(32);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }
        public async Task<ServiceResponseDto<VerificationCodeValidationResult>> ValidateVerificationCode(string email,RolesEnum role, string verificationCode)
        {
            var user = await _uow.Repository<User>().GetByPropAsync(z => z.Email == email&&z.Role==role);
            if (user == null) 
                return new ServiceResponseDto<VerificationCodeValidationResult>(VerificationCodeValidationResult.Invalid,"This Code Is In Valid",false);
            var validationCode = (await _uow.Repository<ValidationCode>().GetAllWithSpecAsync(new GetValidationCodeSpec(user.Id))).FirstOrDefault();

            if (validationCode == null)
            {
                return new ServiceResponseDto<VerificationCodeValidationResult>(VerificationCodeValidationResult.Invalid, "This Code Is In Valid", false);
            }
            else if (validationCode.ExpirationDate < DateTime.Now)
            {
                return new ServiceResponseDto<VerificationCodeValidationResult>(VerificationCodeValidationResult.Expired, "This Code Has Expired", false);
            }
            else if (validationCode.Code != verificationCode)
            {
                return new ServiceResponseDto<VerificationCodeValidationResult>(VerificationCodeValidationResult.Invalid, "This Code Is In Valid", false);

            }

            return new ServiceResponseDto<VerificationCodeValidationResult>(VerificationCodeValidationResult.Valid, "This Code Is Valid", true);

        }
        public async Task<ServiceResponseDto<string>> ResetPasswordAsync(ForgetPasswordRequestDto dto)
        {
            try
            {
                var requestedUser = await _uow.Repository<User>().GetByPropAsync(z => z.Email == dto.Email && z.Role == dto.Role);
                if (requestedUser == null)
                    return new ServiceResponseDto<string>("This Email Does Not Exist", false);

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                requestedUser.Password = passwordHash;

                await _uow.Complete();
                return new ServiceResponseDto<string>("Password reset successfully", true);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return new ServiceResponseDto<string>($"An error occurred while resetting the password: {ex.Message}", false);
            }

        }

        public async Task<bool> EmailExist(string email,RolesEnum role, bool forAdd = true)
        {
            var user = await _uow.Repository<User>().GetByPropAsync(new GetEmailInRoleSpec(email,role));
            if (user != null)
                return true;
            return false;
        }

        public async Task<bool> PhoneExist(string phone,RolesEnum role, bool forAdd = true)
        {
            var user = await _uow.Repository<User>().GetByPropAsync(new GetPhoneInRoleSpec(phone,role));
            if (user != null)
                return true;
            return false;
        }
        public async Task<ServiceResponseDto<AuthModel>> VerifyUserAsync(ValidateVerificationCodeDto verifyDto)
        {
            var user = await _uow.Repository<User>().GetByPropAsync(new GetUserAccountsSpec(verifyDto.Email,verifyDto.Role));
            if (user == null)
                return new ServiceResponseDto<AuthModel>("This email address does not exist. Please check and try again.", false);
            if (user.IsVerified)
                return new ServiceResponseDto<AuthModel>("This account has already been verified.", false);

            var validationResult = await ValidateVerificationCode(verifyDto.Email,verifyDto.Role, verifyDto.VerificationCode);

            switch (validationResult.Data)
            {
                case VerificationCodeValidationResult.Valid:
                    user.IsVerified = true;


                    await _uow.Complete();

                    var token = await _tokenService.CreateToken(user,verifyDto.Role);
                    if (token == null)
                        return new ServiceResponseDto<AuthModel>("Failed to generate authentication token. Please try again.", false);
                    var refreshToken = GenerateRefreshToken();

                    var LoginToReturn = new AuthModel()
                    {
                        IsAuthenticated = true,
                        RefreshToken = refreshToken.Token,
                        RefreshTokenExpiration = refreshToken.ExpiresOn.ToLocalTime(),
                        JwtToken = token,
                        ExpiresOn = _tokenService.ExtractValidToDateFromToken(token)
                    };
                    user.RefreshTokens.Add(refreshToken);
                    await _uow.Complete();

                    return new ServiceResponseDto<AuthModel>(LoginToReturn);

                case VerificationCodeValidationResult.Expired:
                    return new ServiceResponseDto<AuthModel>("The verification code has expired. Please request a new one.", false);
                case VerificationCodeValidationResult.Invalid:
                    return new ServiceResponseDto<AuthModel>("The verification code is invalid. Please check the code and try again.", false);
            }
            return new ServiceResponseDto<AuthModel>("An unexpected error occurred while verifying the code. Please try again.", false);
        }
        public async Task<ServiceResponseDto<string>> SendVerificationCode(string email, RolesEnum role, EmailEnum type)
        {
            var user = await _uow.Repository<User>().GetByPropAsync(z => z.Email == email&&z.Role==role);
            if (user == null)
                return new ServiceResponseDto<string>("No account found with this email address. Please check the email and try again.", false);
            var verificationCode = await GenerateVerificationnCode(user.Id, email);
            await _email.SendEmailAsync(new List<string> { email }, type, user, null, verificationCode);
            return new ServiceResponseDto<string>("A verification code has been sent to your email. Please check your inbox (and spam/junk folder).", true);
        }
        public async Task<ServiceResponseDto<string>?> ValidateUniqueContacts(string? email, string? phone,RolesEnum role)
        {
            if (!string.IsNullOrEmpty(email))
                if (await EmailExist(email,role))
                    return new ServiceResponseDto<string>($"The email address '{email}' is already registered. Please use a different email or sign in with your existing account.", false);
            if (!string.IsNullOrEmpty(phone))
                if (await PhoneExist(phone,role))
                    return new ServiceResponseDto<string>($"The phone number '{phone}' is already registered. Please use a different number or sign in with your existing account.", false);
            return null;
        }
        public async Task<ServiceResponseDto<string>> ChangePasswordAsync(int UserId, ChangePasswordDto dto)
        {
            try
            {
                var requestedUser = await _uow.Repository<User>().GetByIdAsync(UserId);
                if (requestedUser == null)
                    return new ServiceResponseDto<string>("This User Does Not Exist", false);

                if (requestedUser.Password != null)
                {
                    if (!_hasher.VerifyPassword(requestedUser.Password, dto.OldPassword))
                        return new ServiceResponseDto<string>("The Password You Had Entered Is Not Valid", false);
                }
                requestedUser.Password = _hasher.HashPassword(dto.NewPassword);
                await _uow.Complete();
                return new ServiceResponseDto<string>("The Password Has Updated Successfully", true);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return new ServiceResponseDto<string>($"An error occurred while changing the password: {ex.Message}", false);
            }
        }
    }
}
