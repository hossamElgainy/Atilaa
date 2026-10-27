using Core.DomainModels;
using Core.Enums;

namespace Infrastructure.Data.Specifications
{
    public class GetUserAccountsSpec : BaseSpecification<User>
    {
        public GetUserAccountsSpec(string phoneOrEmail, RolesEnum role) : base()
        {
            var value = phoneOrEmail.ToLower();
            Criteria.Add(u => u.Role == role);
            Criteria.Add(u =>
                (u.Email != null && u.Email.ToLower() == value) ||
                (u.Phone != null && u.Phone.ToLower() == value));
            AddInclude(u => u.RefreshTokens);
        }
    }
}
