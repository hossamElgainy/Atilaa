using Core.Dtos;
using Core.Enums;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IFacilityOHService
    {
        Task<ServiceResponseDto<string>> AddFacilityOH(AddFacilityOperationHourDto dto);
        Task<ServiceResponseDto<string>> EditFacilityOH(EditFacilityOperationHourDto dto);
        Task<ServiceResponseDto<List<GetCaptainScheduleDto>>> GetFacilityScheduleForFacility(int ownerId, int branchId, SessionTypeEnum sessionType, BookingTypeEnum type);
        Task<ServiceResponseDto<string>> Delete(int Id);
        Task<ServiceResponseDto<List<GetCaptainScheduleDto>>> GetFacilityScheduleForTrainee(GetFacilityTrainingHoursForTraineeDto dto);

    }
}
