using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IDropInClassService
    {
        Task<ServiceResponseDto<string>> Add(AddOrEditDropInClassDto dto);
        Task<ServiceResponseDto<string>> Edit(AddOrEditDropInClassDto dto);
        Task<ServiceResponseDto<string>> ChangeStatus(int Id);
        Task<PagedResult<GetDropInClassesDto>> GetDropInClassesForTrainee(BasicPaginationParam specParam,double lat,double lang);
        Task<PagedResult<GetDropInClassesDto>> GetCaptainDropInClasses(GetCaptainDropInClassesSpecParam specParam,int userId);
        Task<ServiceResponseDto<GetDropInClassesDetailsDto>> GetDropInClassesDetails(int Id);

    }
}
