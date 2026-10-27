using Core.DomainModels;
using Core.Enums;

namespace Core.Interfaces.IServices.SystemIServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<string> to, EmailEnum emailType,User? user,string? Pass,string? code);
    }
}
