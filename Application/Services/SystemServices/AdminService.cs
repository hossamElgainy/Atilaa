using Application.Services.UsersServices;
using Core.Dtos;
using Core.Dtos.Account;
using Core.DomainModels;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Core.Interfaces.Specifications;

namespace Application.Services.SystemServices
{
    public class AdminService(IUnitOfWork unitOfWork, IPasswordHasher hasher) : IAdminService
    {
        public async Task<ServiceResponseDto<string>> RegisterAsync(RegisterAdminDto model)
        {
            var existing = await unitOfWork.Repository<User>().GetByPropAsync(new GetEmailInRoleSpec(model.Email, RolesEnum.Admin));
            if (existing != null)
                return new ServiceResponseDto<string>("An admin with this email already exists.", false);

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Password = hasher.HashPassword(model.Password ?? string.Empty),
                Role = RolesEnum.Admin,
                IsVerified = true
            };

            await unitOfWork.Repository<User>().AddAsync(user);
            await unitOfWork.Complete();
            return new ServiceResponseDto<string>("Admin registered successfully.", true);
        }
    }
}
