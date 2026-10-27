using Core.Abstraction;
using Core.DomainModels;
using Core.Dtos;
using Core.Dtos.Account;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ICaptainService
    {
        Task<ServiceResponseDto<string>> RegisterBaseData(RegisterCaptainBaseDataDto dto);
        Task<AuthModel> CompleteCaptainData(CompleteCaptainDataDto dto);
        Task<ServiceResponseDto<GetSportsCaptainsDto>> GetBreifCaptainById(int CaptainId);
        Task<ServiceResponseDto<GetCaptainDetailsDto>> GetCaptainDetails(int Id,int UserId);
        Task<PagedResult<GetCaptainsListDto>> GetCaptainsForTrainee(GetCaptainsForTraineeSpecParam specParam);
        Task<PagedResult<GetCaptainsListForAdminDto>> GetCaptainsForAdmin(GetCaptainsForAdminSpecParam specParam);
        Task<ServiceResponseDto<string>> demodata();
        Task<PagedResult<GetCaptainsListDto>> GetSportCaptains(GetSportCaptainsForTraineeSpecParam specParam);
        Task<ServiceResponseDto<GetTraineePerformanceResultDto>> GetCaptainPerformance(int userId,PerformanceFilterEnum filter);
    }
    public class GetTraineePerformanceResultDto
    {
        public int TotalSessions { get; set; }
        public int AttendedSessions { get; set; }
        public int MissedSessions { get; set; }
        public PerformancePeriodItemDto? HighestBookingDay { get; set; }
        public PerformancePeriodItemDto? HighestAttendedDay { get; set; }
        public List<PerformancePeriodItemDto> BreakDown { get; set; } = new();
    }
}
