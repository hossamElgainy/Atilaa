using Core.Dtos;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ISportsService
    {
        Task<ServiceResponseDto<string>> Add(AddOrEditSport dto);
        Task<ServiceResponseDto<string>> Edit(AddOrEditSport dto);
        Task<PagedResult<GetAllSportsDto>> GetAll(GetAllSportsSpecParam specparam, int userId);
        Task<ServiceResponseDto<List<GetAllSportsDto>>> GetBreif(int userId);
        Task<ServiceResponseDto<string>> Delete(int Id);
    }

}
