using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.Dtos;
using Core.Dtos.Logs;
using Core.Enums;

namespace Core.Interfaces.IServices.UsersIServices
{
    public interface IReviewsService
    {
        Task<ServiceResponseDto<string>> Add(AddReviewDto dto,int ReviewerId,RolesEnum role);
        Task<PagedResult<ReviewCardDto>> GetCaptainReviews(BasicPaginationParam specParam,int UserId);
        Task<PagedResult<ReviewCardDto>> GetFacilityReviews(BasicPaginationParam specParam,int OwnerId);
    }
}
