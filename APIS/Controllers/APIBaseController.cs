using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIBaseController : ControllerBase
    {
        public static int GetUserId(ClaimsPrincipal User)
        {
            if(User.Claims.Any())
                return int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            else
                return 0;
        }
    }
}
