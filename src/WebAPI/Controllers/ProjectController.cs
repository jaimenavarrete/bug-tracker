using Application.DTOs.Response;
using Application.DTOs.Request;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetProjects();
            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(projects);

            var response = new ApiResponse<IEnumerable<ProjectResponseDto>>(projectsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(string id)
        {
            var project = await _projectService.GetProjectById(id);
            
            if (project is null)
                throw new EntityNotFoundException(nameof(Project), id);

            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            var response = new ApiResponse<ProjectResponseDto>(projectDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProject(ProjectRequestDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            
            await _projectService.InsertProject(project);
            
            var responseDto = new MiniResponseDto(project.Id);

            var response = new ApiResponse<MiniResponseDto>(responseDto);

            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{project.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(string id, ProjectRequestDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            project.Id = id;

            await _projectService.UpdateProject(project);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            await _projectService.DeleteProject(id);

            return NoContent();
        }
    }
}
