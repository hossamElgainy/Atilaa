using Core.DomainModels;
using Core.Dtos;
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ICaptainOHService
    {
        Task<ServiceResponseDto<string>> Add(AddCaptainOperationHourDto dto);
        Task<ServiceResponseDto<string>> Edit(EditCaptainOperationHourDto dto);
        Task<ServiceResponseDto<string>> Delete(int Id);
        Task<ServiceResponseDto<List<GetCaptainScheduleDto>>> GetCaptainScheduleForCaptain(int userId, SessionTypeEnum sessionType, BookingTypeEnum type);
        Task<ServiceResponseDto<List<GetCaptainScheduleDto>>> GetCaptainScheduleForTrainee(GetCaptainTrainingPlacesDto dto, SessionTypeEnum SessionType, BookingTypeEnum BookingType);
    }
}
