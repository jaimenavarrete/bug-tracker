using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class LookupDataController : ControllerBase
    {
        private readonly ILookupDataService _lookupDataService;
        private readonly IMapper _mapper;

        public LookupDataController(ILookupDataService lookupDataService, IMapper mapper)
        {
            _lookupDataService = lookupDataService;
            _mapper = mapper;
        }

        [HttpGet("gravityLevels")]
        public async Task<IActionResult> GetGravityLevels()
        {
            var gravityLevels = await _lookupDataService.GetGravityLevels();
            var gravityLevelsDto = _mapper.Map<IEnumerable<LookupResponseDto>>(gravityLevels);

            return Ok(gravityLevelsDto);
        }

        [HttpGet("gravityLevels/{id}")]
        public async Task<IActionResult> GetGravityLevelById(int id)
        {
            var gravityLevel = await _lookupDataService.GetGravityLevelById(id);

            if (gravityLevel is null)
                throw new EntityNotFoundException(nameof(GravityLevel), id.ToString());

            var gravityLevelDto = _mapper.Map<LookupResponseDto?>(gravityLevel);

            return Ok(gravityLevelDto);
        }

        [HttpGet("classifications")]
        public async Task<IActionResult> GetClassifications()
        {
            var classifications = await _lookupDataService.GetClassifications();
            var classificationsDto = _mapper.Map<IEnumerable<LookupResponseDto>>(classifications);

            return Ok(classificationsDto);
        }

        [HttpGet("classifications/{id}")]
        public async Task<IActionResult> GetClassificationById(int id)
        {
            var classification = await _lookupDataService.GetGravityLevelById(id);

            if (classification is null)
                throw new EntityNotFoundException(nameof(Classification), id.ToString());

            var classificationDto = _mapper.Map<LookupResponseDto?>(classification);

            return Ok(classificationDto);
        }

        [HttpGet("reproducibilityLevels")]
        public async Task<IActionResult> GetReproducibilityLevels()
        {
            var reproducibilityLevel = await _lookupDataService.GetReproducibilityLevels();

            var reproducibilityLevelDto = _mapper.Map<IEnumerable<LookupResponseDto>>(reproducibilityLevel);

            return Ok(reproducibilityLevelDto);
        }

        [HttpGet("reproducibilityLevels/{id}")]
        public async Task<IActionResult> GetReproducibilityLevelById(int id)
        {
            var reproducibilityLevel = await _lookupDataService.GetReproducibilityLevelById(id);

            if (reproducibilityLevel is null)
                throw new EntityNotFoundException(nameof(ReproducibilityLevel), id.ToString());

            var reproducibilityLevelDto = _mapper.Map<LookupResponseDto?>(reproducibilityLevel);

            return Ok(reproducibilityLevelDto);
        }

    }
}