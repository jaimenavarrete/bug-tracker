using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
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

        [HttpGet("classifications")]
        public async Task<IActionResult> GetClassifications()
        {
            var classifications = await _lookupDataService.GetClassifications();
            var classificationsDto = _mapper.Map<IEnumerable<LookupResponseDto>>(classifications);

            return Ok(classificationsDto);
        }

        [HttpGet("reproducibilityLevels")]
        public async Task<IActionResult> GetReproducibilityLevels()
        {
            var reproducibilityLevel = await _lookupDataService.GetReproducibilityLevels();
            var reproducibilityLevelDto = _mapper.Map<IEnumerable<LookupResponseDto>>(reproducibilityLevel);

            return Ok(reproducibilityLevelDto);
        }
    }
}