using Core.DomainModels;
using Core.Enums;
using Infrastructure.Data.Specifications;

namespace Application.Services.UsersServices
{
    public class GetEmailInRoleSpec : BaseSpecification<User>
    {
        public GetEmailInRoleSpec(string email,RolesEnum role):base()
        {
            Criteria.Add(u => u.Email != null && u.Email.ToLower() == email.ToLower());
            Criteria.Add(u => u.Role == role);
        }
    }
}
