using Core.DomainModels;

namespace Infrastructure.Data.Specifications
{
    public class GetUserRefreshTokensSpecification : BaseSpecification<User>
    {
        public GetUserRefreshTokensSpecification(int userId) : base()
        {
            Criteria.Add(u => u.Id == userId);
            AddInclude(u => u.RefreshTokens);
        }

        public GetUserRefreshTokensSpecification(string token) : base()
        {
            Criteria.Add(u => u.RefreshTokens.Any(t => t.Token == token));
            AddInclude(u => u.RefreshTokens);
        }
    }
}
