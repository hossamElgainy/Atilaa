using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IPartnersService
    {
        Task<ServiceResponseDto<PartnerDto>> CreateAsync(CreatePartnerDto dto);
        Task<ServiceResponseDto<PartnerDto>> UpdateAsync(int id, CreatePartnerDto dto);
        Task<ServiceResponseDto<string>> DeleteAsync(int id);
        Task<PartnerDto?> GetByIdAsync(int id);
        Task<PagedResult<PartnerDto>> GetAllAsync(BasicPaginationParam pagination = null);
    }
}
