using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/ticketTags")]
    [ApiController]
    public class TicketTagController : ControllerBase
    {
        private readonly ITicketTagService _ticketTagService;
        private readonly IMapper _mapper;

        public TicketTagController(ITicketTagService ticketTagService, IMapper mapper)
        {
            _ticketTagService = ticketTagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketTags()
        {
            var ticketTags = await _ticketTagService.GetTicketTags();
            var ticketTagsDto = _mapper.Map<IEnumerable<TicketTagResponseDto>>(ticketTags);

            var response = new ApiResponse<IEnumerable<TicketTagResponseDto>>(ticketTagsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketTagById(string id)
        {
            var ticketTag = await _ticketTagService.GetTicketTagById(id);
            if (ticketTag is null)
                throw new EntityNotFoundException(nameof(TicketTag), id);

            var ticketTagDto = _mapper.Map<TicketTagResponseDto>(ticketTag);

            var response = new ApiResponse<TicketTagResponseDto>(ticketTagDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTicketTag(TicketTagRequestDto ticketTagRequestDto)
        {
            var ticketTag = _mapper.Map<TicketTag>(ticketTagRequestDto);
            await _ticketTagService.InsertTicketTag(ticketTag);

            var responseDto = new MiniResponseDto(ticketTag.Id);

            var response = new ApiResponse<MiniResponseDto>(responseDto);

            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{ticketTag.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketTag(string id, TicketTagRequestDto ticketTagDto)
        {
            var ticketTag = _mapper.Map<TicketTag>(ticketTagDto);
            ticketTag.Id = id;

            await _ticketTagService.UpdateTicketTag(ticketTag);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketTag(string id)
        {
            await _ticketTagService.DeleteTicketTag(id);

            return NoContent();
        }
    }
}
