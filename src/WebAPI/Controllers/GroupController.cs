using Application.DTOs.Request;
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
            var groupsDto = _mapper.Map<IEnumerable<GroupMiniResponseDto>>(groups);

            var response = new ApiResponse<IEnumerable<GroupMiniResponseDto>>(groupsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(string id)
        {
            var group = await _groupService.GetGroupById(id);

            if (group is null)
                throw new EntityNotFoundException(nameof(Group), id);

            var groupDto = _mapper.Map<GroupResponseDto>(group);

            var response = new ApiResponse<GroupResponseDto>(groupDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertGroup(GroupRequestDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            await _groupService.InsertGroup(group);

            var responseDto = new CreationResponseDto(group.Id);

            var response = new ApiResponse<CreationResponseDto>(responseDto);

            return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(string id, GroupRequestDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            group.Id = id;

            await _groupService.UpdateGroup(group);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(string id)
        {
            await _groupService.DeleteGroup(id);

            return NoContent();
        }
    }
}
