using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetLoggedUser()
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
                throw new AuthenticationException("There was a problem trying to get the current user information.");

            var userClaims = identity.Claims;
            var userId = userClaims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var user = await _userService.GetUserById(userId);
            var userDto = _mapper.Map<UserResponseDto>(user);

            var response = new ApiResponse<UserResponseDto>(userDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUserRequestDto loginUser)
        {
            var user = await _userService.GetUserByCredentials(loginUser.Email, loginUser.Password);

            if (user is null)
                throw new InvalidCredentialException("The user or the password was incorrect.");

            var token = _tokenService.GenerateToken(user);

            var tokenDto = new LoginUserResponseDto(token);

            var response = new ApiResponse<LoginUserResponseDto>(tokenDto);

            return Ok(response);
        }
    }
}
