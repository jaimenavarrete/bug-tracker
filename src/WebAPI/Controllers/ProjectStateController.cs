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
    [Route("api/projectStates")]
    [ApiController]
    public class ProjectStateController : ControllerBase
    {
        private readonly IProjectStateService _projectStateService;
        private readonly IMapper _mapper;

        public ProjectStateController(IProjectStateService projectStateService, IMapper mapper)
        {
            _projectStateService = projectStateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectStates()
        {
            var projectStates = await _projectStateService.GetProjectStates();
            var projectStatesDto = _mapper.Map<IEnumerable<ProjectStateAndTagMiniResponseDto>>(projectStates);

            var response = new ApiResponse<IEnumerable<ProjectStateAndTagMiniResponseDto>>(projectStatesDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectStateById(string id)
        {
            var projectState = await _projectStateService.GetProjectStateById(id);
            if (projectState is null)
                throw new EntityNotFoundException(nameof(ProjectState), id);

            var projectStateDto = _mapper.Map<ProjectStateAndTagResponseDto>(projectState);

            var response = new ApiResponse<ProjectStateAndTagResponseDto>(projectStateDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProjectState(ProjectStateRequestDto projectStateRequestDto)
        {
            var projectState = _mapper.Map<ProjectState>(projectStateRequestDto);
            await _projectStateService.InsertProjectState(projectState);

            var responseDto = new CreationResponseDto(projectState.Id);

            var response = new ApiResponse<CreationResponseDto>(responseDto);

            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{projectState.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectState(string id, ProjectStateRequestDto projectStateDto)
        {
            var projectState = _mapper.Map<ProjectState>(projectStateDto);
            projectState.Id = id;

            await _projectStateService.UpdateProjectState(projectState);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectState(string id)
        {
            await _projectStateService.DeleteProjectState(id);

            return NoContent();
        }
    }
}
