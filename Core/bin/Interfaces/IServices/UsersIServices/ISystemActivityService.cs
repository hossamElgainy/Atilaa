using Core.Enums;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ISystemActivityService
    {
        Task LogActivityAsync(
            int userId,
            SystemActivityEnum type,
            string title,
            string body,
            int? entityId = null,
            string? entityType = null);
    }
}
