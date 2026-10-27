using Core.Dtos;
using System.Reflection.PortableExecutable;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IKidsService
    {
        Task<ServiceResponseDto<string>> Register(RegisterKidDto dto,int ParentId);
        Task<ServiceResponseDto<List<GetUserKidsDto>>> GetUserKids(int userId);
        Task<ServiceResponseDto<string>> Edit(RegisterKidDto dto, int id);
        Task<ServiceResponseDto<GetKidDetailsDto>> GetKidDetailsForParent(int id);
        //Task<ServiceResponseDto<GetKidDetailsDto>> GetKidDetailsForCaptain(int id,int userId); //userId for the captain
        Task<ServiceResponseDto<GetKidForEditDto>> GetKidForEdit(int id);
        Task<ServiceResponseDto<string>> DeleteKid(int id);
    }
}
