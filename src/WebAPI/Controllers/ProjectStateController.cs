using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
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
            var projectStatesDto = _mapper.Map<IEnumerable<ProjectStateResponseDto>>(projectStates);

            var response = new ApiResponse<IEnumerable<ProjectStateResponseDto>>(projectStatesDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectStateById(string id)
        {
            var projectState = await _projectStateService.GetProjectStateById(id);
            if (projectState is null)
                throw new EntityNotFoundException("The project state you are looking for does not exist.");

            var projectStateDto = _mapper.Map<ProjectStateResponseDto>(projectState);

            var response = new ApiResponse<ProjectStateResponseDto>(projectStateDto);

            return Ok(response);
        }
    }
}
