using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Services;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            var usersDto = _mapper.Map<IEnumerable<UserMiniResponseDto>>(users);

            var response = new ApiResponse<IEnumerable<UserMiniResponseDto>>(usersDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            await _userService.CreateUser(user);

            var responseDto = new CreationResponseDto(user.Id);

            var response = new ApiResponse<CreationResponseDto>(responseDto);

            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{user.Id}", response);
        }
    }
}
