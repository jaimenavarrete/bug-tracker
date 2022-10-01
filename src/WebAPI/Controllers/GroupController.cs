using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await _groupService.GetGroups();
            var groupsDto = _mapper.Map<IEnumerable<GroupResponseDto>>(groups);

            var response = new ApiResponse<IEnumerable<GroupResponseDto>>(groupsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroups(string id)
        {
            var group = await _groupService.GetGroupById(id);
            if (group is null)
                throw new EntityNotFoundException("The group you are looking for does not exist.");

            var groupDto = _mapper.Map<GroupResponseDto>(group);

            var response = new ApiResponse<GroupResponseDto>(groupDto);

            return Ok(response);
        }
    }
}
