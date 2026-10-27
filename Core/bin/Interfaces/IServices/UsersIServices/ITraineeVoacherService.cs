using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ITraineeVoacherService
    {
        Task<PagedResult<GetTraineeVoacherHistoryDto>> GetTraineeVoacherHistory(BasicPaginationParam specParam,int userId);
        Task<ServiceResponseDto<GetTraineeVoacherDetailsDto>> GetTraineeVoacher(int userId);
    }
}
