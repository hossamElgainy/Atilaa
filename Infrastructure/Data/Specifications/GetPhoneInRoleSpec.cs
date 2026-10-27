using Core.DomainModels;
using Core.Enums;

namespace Infrastructure.Data.Specifications
{
    public class GetPhoneInRoleSpec : BaseSpecification<User>
    {
        public GetPhoneInRoleSpec(string phone, RolesEnum role) : base()
        {
            Criteria.Add(u => u.Phone != null && u.Phone.ToLower() == phone.ToLower());
            Criteria.Add(u => u.Role == role);
        }
    }
}
