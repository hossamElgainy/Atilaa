using APIS.Controllers;
using AshalLms.Core.Interfaces.Specification.SpecParams;
using Core.DomainModels;
using Core.Dtos.Account;
using Core.Dtos.Logs;
using Core.Dtos.Response;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Core.Interfaces.IServices.UsersIServices;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Captiny.APIS.Controllers
{
    public class UserController(IUsersService _service, IAdminService _admin, AppDbContext _db) : APIBaseController
    {
        private const string FixedAdminEmail = "admin@captiny.com";

        [HttpDelete("[action]")]
        public async Task<ActionResult<StandardResponse<string>>> Delete(int Id)
        {
            var result = await _service.Delete(Id);
            if (result.IsSuccess)
                return Ok(new StandardResponse<string>(result.Message));
            return BadRequest(new StandardResponse<string>(result.Message, false));
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<StandardResponse<string>>> RegisterAdminAsync([FromForm]RegisterAdminDto model)
        {
            var result = await _admin.RegisterAsync(model);
            if (result.IsSuccess)
                return Ok(new StandardResponse<string>(result.Message));
            return BadRequest(new StandardResponse<string>(result.Message, false));
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<ActionResult<AuthModel>> UpdateProfileImage(IFormFile Image)
        {
            var UserId = GetUserId(User);
            var result = await _service.UpdateProfileImage(Image,UserId);
            return Ok(result);
        }
        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _db.Users.Select(u => new { u.Id, u.Name }).ToListAsync());
        }

   
     

       
        public class ChatContactDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Image { get; set; } = string.Empty;
            public RolesEnum Role { get; set; }
            public bool IsOnline { get; set; }
            public DateTime? LastMessageAt { get; set; }
        }

        public class PagedChatContactsDto
        {
            public List<ChatContactDto> Items { get; set; } = new();
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public int TotalCount { get; set; }
        }

        public class ConversationMessageDto
        {
            public int Id { get; set; }
            public int SenderId { get; set; }
            public int ReceiverId { get; set; }
            public string Content { get; set; } = string.Empty;
            public DateTime Timestamp { get; set; }
            public string Status { get; set; } = string.Empty;
            public int StatusChecks { get; set; }
        }
    }
}
