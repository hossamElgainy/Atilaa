using Core.Dtos;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IFavouriteFacilityService
    {
        Task<ServiceResponseDto<string>> Add(int facilityId,int branchId, int userId);
        Task<ServiceResponseDto<string>> Delete(int facilityId, int branchId, int userId);
    }
}
