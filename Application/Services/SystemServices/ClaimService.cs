
using Core.DomainModels;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Core.Interfaces.IServices.UsersIServices;
using Core.Interfaces.Specifications;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Application.Services.SystemServices
{
    public class ClaimService
    {
        public async Task<ClaimsIdentity> CreateClaimsIdentityForUserAsync(User user,RolesEnum? role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("Phone", $"{user.Phone}"),
                new Claim("Email", $"{user.Email}"),
                new Claim("Name", user.Name),
                new Claim("Role",  user.Role.ToString()),
                
            };
            return new ClaimsIdentity(claims);
        }
    }
}
