using Core.Dtos;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ICaptainWorkService
    {
        Task<ServiceResponseDto<string>> Add(AddCaptainWorkDto dto,int userId);
        Task<ServiceResponseDto<string>> Delete(int Id);
        Task<ServiceResponseDto<List<CommunityWorkDto>>> Get(int userId);
    }
}
