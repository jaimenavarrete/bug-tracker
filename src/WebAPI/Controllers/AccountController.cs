using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Services;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginRequestDto userLogin)
        {
            var user = await _userService.GetUserByCredentials(userLogin.Email, userLogin.Password);

            if (user is null)
                throw new InvalidCredentialException("The user or the password was incorrect.");

            var token = _tokenService.GenerateToken(user);

            var responseDto = new UserLoginResponseDto(token);

            var response = new ApiResponse<UserLoginResponseDto>(responseDto);

            return Ok(response);
        }
    }
}
