using Application.Services.SystemServices;
using Core.DomaimModels;
using Core.DomainModels;
using Core.Dtos;
using Core.Dtos.Account;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Core.Interfaces.IServices.UsersIServices;
using Core.Interfaces.Specification;
using Core.Interfaces.Specifications;
using Infrastructure.Data.Specifications;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace Application.Services.UsersServices
{
    public class UsersService(IUnitOfWork _unitOfWork,IFileService _file, ITokenService _tokenService) : IUsersService
    {
        public async Task<ServiceResponseDto<string>> Delete(int Id)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(Id);
            if (user == null)
                return new ServiceResponseDto<string>("File not found", false);
            try
            {

                user.IsDeleted = true;
                await _unitOfWork.Complete();
                return new ServiceResponseDto<string>("User successfully", true);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return new ServiceResponseDto<string>($"An error occurred: {ex.Message}", false);
            }
        }
        

        public async Task<AuthModel> UpdateProfileImage(IFormFile Image, int UserId)
        {
            var authModel = new AuthModel();

            var user = await _unitOfWork.Repository<User>().GetByIdAsync(new GetUserRefreshTokensSpecification(UserId));
            if (user is null)
            {
                authModel.Message = "Error Getting Your Data";
                return authModel;
            }
            user.Image = await _file.UploadFileAsync(Image, FilesTypeEnum.Users.ToString());
             await _unitOfWork.Complete();
            var jwtSecurityToken = await _tokenService.CreateToken(user, user.Role);

            authModel.IsAuthenticated = true;
            authModel.JwtToken = jwtSecurityToken;
            authModel.ExpiresOn = _tokenService.ExtractValidToDateFromToken(jwtSecurityToken);

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn.ToLocalTime();
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn.ToLocalTime();
                user.RefreshTokens.Add(refreshToken);
                await _unitOfWork.Complete();
            }

            return authModel;
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

    }
}
