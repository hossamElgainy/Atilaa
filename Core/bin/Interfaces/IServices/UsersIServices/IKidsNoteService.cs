using Core.Dtos;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IKidsNoteService
    {
        Task<ServiceResponseDto<string>> Add(AddKidsNoteDto dto,int UserId);
    }
}
