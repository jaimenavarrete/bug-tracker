using Application.DTOs;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectRepository.GetAll();
            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(projects);

            return Ok(projectsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(string id)
        {
            var project = await _projectRepository.GetById(id);
            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            return Ok(projectDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProject(ProjectRequestDto projectDto)
        {
            var userId = Guid.NewGuid().ToString();

            var project = _mapper.Map<Project>(projectDto);
            project.AddCreationInfo(userId);

            await _projectRepository.Insert(project);

            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(string id, ProjectRequestDto projectDto)
        {
            var userId = Guid.NewGuid().ToString();

            var project = await _projectRepository.GetById(id);
            project = _mapper.Map(projectDto, project);
            project.UpdateModificationInfo(userId);

            await _projectRepository.Update(project);

            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var result = await _projectRepository.Delete(id);

            return Ok(result);
        }
    }
}
