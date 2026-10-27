using Core.Dtos;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ICaptainFacilitiesService
    {
        Task<ServiceResponseDto<List<GetCaptainTrainingPlacesDto>>> GetCaptainTrainingPlaces(int captainId);        
        Task<ServiceResponseDto<object>> GetBreifCaptainOrFacility(GetCaptainTrainingPlacesDto dto, double lat, double lang,int userId);
        Task<PagedResult<GetCaptainsListDto>> GetFacilityCaptains(GetFacilityCaptainsSpecParam specParam);
    }
}
