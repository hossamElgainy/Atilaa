using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ILeaderBoardService
    {
        Task<PagedResult<GetTopThreeOnLeaderBoardDto>> TraineesLeaderBoard(BasicPaginationParam specParam, int userId);
        Task<PagedResult<GetTopThreeOnLeaderBoardDto>> CaptainsLeaderBoard(BasicPaginationParam specParam, int userId);
        Task<PagedResult<GetTopThreeOnLeaderBoardDto>> FacilitiesLeaderBoard(BasicPaginationParam specParam);
        Task<ServiceResponseDto<List<GetTopThreeOnLeaderBoardDto>>> GetTop3Trainees(int userId);
        Task<ServiceResponseDto<List<GetTopThreeOnLeaderBoardDto>>> GetTop3Captains(int userId);
        Task<ServiceResponseDto<GetTopThreeOnLeaderBoardDto>> GetTop3Facilities();

    }
}
