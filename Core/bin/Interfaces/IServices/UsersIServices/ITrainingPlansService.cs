using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ITrainingPlansService
    {
        Task<ServiceResponseDto<string>> Add(UploadPlanDto dto,int UserId);
        Task<PagedResult<GetTrainingPlansForKidDto>> GetKidTrainingPlans(BasicPaginationParam specParam, int KidId);
        Task<PagedResult<GetTrainingPlansForTraineeDto>> GetTraineeTrainingPlans(BasicPaginationParam specParam, int userId);
        Task<ServiceResponseDto<List<GetTrainingPlanFilesDto>>> GetTraineePlanFiles(int captainId,int traineeId);

    }
}
