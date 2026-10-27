using Core.DomainModels;
using Core.Dtos;
using Core.Dtos.Account;
using Core.Dtos.Logs;
using Core.Interfaces.Specification;
using Core.Interfaces.Specification.SpecParams;
using System.Collections;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IFacilityService
    {
        Task<ServiceResponseDto<string>> AddBasicData(RegisterFacilityBaseDataDto dto);
        Task<AuthModel> CompleteFacilityData(CompleteFacilityDataDto dto);
        Task<PagedResult<GetFacilitiesListDto>> GetFacilitiesForTrainee(GetCaptainsForTraineeSpecParam specParam,double lat,double lang);
        Task<ServiceResponseDto<MobileFacilityMobileHomeStatisticsDto>> MobileHomeStatistics(int facilityId,int? branchId,int? sportId);
        Task<ServiceResponseDto<GetFacilityDetailsDto>> GetFacilityDetails(int facilityId,int branchId,int userId);
        Task<PagedResult<GetFacilitiesListDto>> GetSportFacilitiesForTrainee(GetSportFacilitiesForTraineeSpecParam specParam, double lat, double lang);
        Task<ServiceResponseDto<GetFacilityPerformanceResultDto>> GetFacilityPerformance(
    int userId,     
    int? branchId,      
    PerformanceFilterEnum filter);
    }
    public class GetFacilityPerformanceResultDto
    {
        public int TotalBookings { get; set; }
        public int CompletedBookings { get; set; }   // or CompletedSessions if you prefer
        public int MissedBookings { get; set; }      // TotalBookings - CompletedBookings

        public int TotalViews { get; set; }

        // Highest days
        public PerformancePeriodItemDto? HighestBookingDay { get; set; }
        public PerformancePeriodItemDto? HighestViewDay { get; set; }

        public List<PerformancePeriodItemDto> BreakDown { get; set; } = new();
    }
}
