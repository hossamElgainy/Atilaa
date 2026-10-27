using Core.Dtos;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IBookService
    {
        Task<ServiceResponseDto<string>> Add(AddBookingDto dto,int UserId);        
        Task<ServiceResponseDto<string>> Reschedule(RescheduleBookingDto dto);        
        Task<ServiceResponseDto<string>> ChangeStatus(ChangeBookingStatusDto dto);
        Task<ServiceResponseDto<GetBookingDetailsDto>> GetTraineeBookingDetails(int BookingId);
        Task<PagedResult<GetTraineeBookingsDto>> GetTraineeBookings(GetTraineeBookingSpecParam specParam,int UserId);
        Task<PagedResult<GetCaptainBookingsDto>> GetCaptainBookings(GetCaptainBookingSpecParam specParam,int UserId);
        Task<PagedResult<GetCaptainBookingsDto>> GetFacilityBookings(GetCaptainBookingSpecParam specParam,int UserId);
        Task<PagedResult<GetTraineeBookingRequestsDto>> GetBookingRequestsForTrainee(GetTraineeBookingRequestsSpecParam specParam,int UserId);
        
    }
}
