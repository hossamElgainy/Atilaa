using Core.DomainModels;
using Core.Enums;
using Infrastructure.Data.Specifications;

namespace Infrastructure.Data.Specifications
{
    public class GetUsersInRoleSpec : BaseSpecification<User>
    {
        public GetUsersInRoleSpec(RolesEnum roleName) : base()
        {
            Criteria.Add(x => x.Role==roleName);
        }

    }

}

