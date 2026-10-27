using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;
using Core.Interfaces.Specification.SpecParams;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IAnnouncementService
    {
        Task<ServiceResponseDto<string>> Add(AddAnnouncementDto dto);
        Task<ServiceResponseDto<string>> Edit(EditAnnouncementDto dto);
        Task<PagedResult<GetAllAnnounceMentsDto>> GetAllAnnounceMents(GetAdminAnnouncementsSpecParam specparam);
        Task<ServiceResponseDto<List<GetAllAnnounceMentsDto>>> GetActiveAnnouncement();
        Task<ServiceResponseDto<string>> Delete(int Id);
    }
}
