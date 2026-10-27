using Core.Dtos;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IViewsService
    {
        Task<ServiceResponseDto<string>> Add(AddViewAcademyRecordDto dto,int TraineeId);
        Task<PagedResult<ViewsListDto>> GetAll(GetAllFacilityViewsSpecParam specparam);
    }
}
