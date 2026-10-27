using APIS.Controllers;
using Application.Services.UsersServices;
using Core.DomainModels;
using Core.Dtos;
using Core.Dtos.Account;
using Core.Dtos.Response;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Captiny.APIS.Controllers
{
    public class AuthController : APIBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

      
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto model)
        {
            var result = await _authService.LoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            if(!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }


       
        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
           
             var result = await _authService.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("revokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenDto model)
        {

            if (string.IsNullOrEmpty(model.Token))
                return BadRequest("Token is required!");

            var result = await _authService.RevokeTokenAsync(model.Token);

            if(!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendVerificationCode(string email,RolesEnum role, EmailEnum EmailType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.SendVerificationCode(email,role, EmailType);

            if (result.IsSuccess)
                return Ok(new StandardResponse<string>(result.Message));
            return BadRequest(new StandardResponse<string>(result.Message, false));
        }

        [HttpPost("ForgetPassword")]
        public async Task<ActionResult> ForgetPassword([FromForm] ForgetPasswordRequestDto forgetPasswordRequest)
        {
            var result = await _authService.ResetPasswordAsync(forgetPasswordRequest);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("ValidateCode")]
        public async Task<ActionResult<StandardResponse<VerificationCodeValidationResult>>> ValidateCode([FromQuery] ValidateVerificationCodeDto model)
        {         
            var result = await _authService.ValidateVerificationCode(model.Email,model.Role,model.VerificationCode);           
            if (result.IsSuccess)
                return Ok(new StandardResponse<VerificationCodeValidationResult>(result.Data,result.Message));
            else
                return BadRequest(new StandardResponse<VerificationCodeValidationResult>(result.Message,false));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> VerifyUser([FromQuery] ValidateVerificationCodeDto model)
        {         
            var result = await _authService.VerifyUserAsync(model);    
            if(result.IsSuccess)
                return Ok(new StandardResponse<AuthModel>(result.Data));
            return BadRequest(new StandardResponse<AuthModel>(result.Message,false));
        }
        [Authorize]
        [HttpPost("[action]"), Consumes("multipart/form-data")]
        public async Task<ActionResult<StandardResponse<string>>> ChangePassword([FromForm]ChangePasswordDto dto)
        {
            var userId = GetUserId(User);
            var result = await _authService.ChangePasswordAsync(userId,dto);    
            if(result.IsSuccess)
                return Ok(new StandardResponse<string>(result.Message));
            return BadRequest(new StandardResponse<AuthModel>(result.Message,false));
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                 HttpOnly = true,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
