using Core.Dtos;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface ICaptainCertificationService
    {
        Task<ServiceResponseDto<string>> Add(IFormFile Certificate ,int userId);
        Task<ServiceResponseDto<string>> Delete(int Id);
        Task<ServiceResponseDto<List<CaptainCertificatesDto>>> Get(int userId);
    }
}
