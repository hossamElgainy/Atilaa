using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Abstraction;
using Core.Dtos;
using Core.Dtos.Account;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ITraineeService
    {
        Task<ServiceResponseDto<string>> RegisterBaseData(RegisterTraineeBaseDataDto dto);
        Task<ServiceResponseDto<string>> CompleteTraineeData(CompleteTraineeDataDto dto);
        Task<PagedResult<object>> GetMyFavourites(int userId,GetTraineeFavouritesSpecParam specParam);
        Task<PagedResult<GetFacilityTraineesDto>> GetFacilityTrainees(GetFacilityTraineesSpecParam specParam);
        Task<PagedResult<GetFacilityTraineesDto>> GetCaptainTrainees(GetCaptainTraineesSpecParam specParam,int userId);
        Task<AuthModel> EditPersonalData(EditTraineePersonalDataDto dto,int UserId);
        Task<ServiceResponseDto<GetPersonalDataDto>> GetTraineePersonalData(int userId);
        Task<ServiceResponseDto<GetTraineeProfileSummaryDto>> GetTraineeProfileSummary(int userId);
        Task<ServiceResponseDto<List<GetNearestPlacesOnMapDto>>> GetNearestPlacesOnMap(GetCaptainsForTraineeSpecParam specParam, double lat,double lang);
        Task<ServiceResponseDto<List<GetTraineeLocationsDto>>> GetTraineeLocations(int userId);
        Task<ServiceResponseDto<GetKidDetailsDto>> GetTraineeDetailsForCaptain(int id, int userId,bool IsKid);
        Task<ServiceResponseDto<GetTraineeProgressDto>> GetTraineeProgress(int userId, int? captainId);
        Task<ServiceResponseDto<List<GetCaptainsBookedFromDto>>> GetCaptainsBookedFrom(int userId);
        Task<ServiceResponseDto<List<PerformancePeriodItemDto>>> GetTraineePerformance(int userId,int? captainId,PerformanceFilterEnum filter);
        Task<PagedResult<GetAdminTraineesDto>> GetTraineeForAdmin(GetTraineesForAdminSpecParam specParam);
        }

    public class GetAdminTraineesDto:BaseEntityInt
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public int KidsCount { get; set; }
        public bool IsNew { get; set; }
    }

    public class GetTraineesForAdminSpecParam:BasicPaginationParam
    {
        public string? SearchParam { get; set; }
    }

    public enum PerformanceFilterEnum
    {
        Weekly = 1,
        Monthly = 2,
        Yearly = 3
    }

    public class GetTraineePerformanceDto
    {
        public int TotalSessions { get; set; }
        public int AttendedSessions { get; set; }
        public double AttendanceRate { get; set; }
        public string Period { get; set; }
        public List<PerformancePeriodItemDto> BreakDown { get; set; } = new();
    }

    public class PerformancePeriodItemDto
    {
        public string Label { get; set; }
        public int TotalSessions { get; set; }
        public int AttendedSessions { get; set; }
        public double AttendanceRate { get; set; }
    }
}
