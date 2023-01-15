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
    [Route("api/projectTags")]
    [ApiController]
    public class ProjectTagController : ControllerBase
    {
        private readonly IProjectTagService _projectTagService;
        private readonly IMapper _mapper;

        public ProjectTagController(IProjectTagService projectTagService, IMapper mapper)
        {
            _projectTagService = projectTagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectTags()
        {
            var projectTags = await _projectTagService.GetProjectTags();
            var projectTagsDto = _mapper.Map<IEnumerable<ProjectTagResponseDto>>(projectTags);

            var response = new ApiResponse<IEnumerable<ProjectTagResponseDto>>(projectTagsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectTagById(string id)
        {
            var projectTag = await _projectTagService.GetProjectTagById(id);
            if (projectTag is null)
                throw new EntityNotFoundException(nameof(ProjectTag), id);

            var projectTagDto = _mapper.Map<ProjectTagResponseDto>(projectTag);

            var response = new ApiResponse<ProjectTagResponseDto>(projectTagDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProjectTag(ProjectTagRequestDto projectTagRequestDto)
        {
            var projectTag = _mapper.Map<ProjectTag>(projectTagRequestDto);
            await _projectTagService.InsertProjectTag(projectTag);

            var responseDto = new CreationResponseDto(projectTag.Id);

            var response = new ApiResponse<CreationResponseDto>(responseDto);

            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{projectTag.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectTag(string id, ProjectTagRequestDto projectTagDto)
        {
            var projectTag = _mapper.Map<ProjectTag>(projectTagDto);
            projectTag.Id = id;

            await _projectTagService.UpdateProjectTag(projectTag);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectTag(string id)
        {
            await _projectTagService.DeleteProjectTag(id);

            return NoContent();
        }
    }
}
