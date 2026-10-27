using Core.Dtos;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IFacilityWorkService
    {
        Task<ServiceResponseDto<string>> Add(AddCaptainWorkDto dto,int ownerId);
        Task<ServiceResponseDto<string>> Delete(int Id);
        Task<ServiceResponseDto<List<CommunityWorkDto>>> Get(int userId);
    }
}
