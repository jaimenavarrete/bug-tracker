using Application.DTOs;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/project")]
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
                throw new EntityNotFoundException("The project you are looking for does not exist.");

            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            var response = new ApiResponse<ProjectResponseDto>(projectDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProject(ProjectRequestDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _projectService.InsertProject(project);
            var responseDto = _mapper.Map<ProjectResponseDto>(project);

            var response = new ApiResponse<ProjectResponseDto>(responseDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(string id, ProjectRequestDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            project.Id = id;

            var result = await _projectService.UpdateProject(project);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var result = await _projectService.DeleteProject(id);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
