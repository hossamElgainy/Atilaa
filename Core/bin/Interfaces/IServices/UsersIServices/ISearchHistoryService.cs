using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;
using Core.Enums;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ISearchHistoryService
    {
        Task<ServiceResponseDto<string>> Add(string SearchTerm, int UserID);
        Task<ServiceResponseDto<string>> Delete(int Id);
        Task<ServiceResponseDto<string>> DeleteAll(int UserId);
        Task<PagedResult<GetAllSerchHistoryDto>> GetAll(BasicPaginationParam specparam,int userId);
        Task<PagedResult<object>> GetFilteredDataAsync(
            FilterTypeEnum type,
            GetHomeFilterForTraineeSpecParam specParam,
            int userId,
            double lat,
            double lang);
    }
}
