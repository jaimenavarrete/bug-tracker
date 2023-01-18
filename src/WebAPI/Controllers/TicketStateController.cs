using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/ticketStates")]
    [ApiController]
    public class TicketStateController : ControllerBase
    {
        private readonly ITicketStateService _ticketStateService;
        private readonly IMapper _mapper;

        public TicketStateController(ITicketStateService ticketStateService, IMapper mapper)
        {
            _ticketStateService = ticketStateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketStates()
        {
            var ticketStates = await _ticketStateService.GetTicketStates();
            var ticketStatesDto = _mapper.Map<IEnumerable<TicketStateAndTagMiniResponseDto>>(ticketStates);

            var response = new ApiResponse<IEnumerable<TicketStateAndTagMiniResponseDto>>(ticketStatesDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketStateById(string id)
        {
            var ticketState = await _ticketStateService.GetTicketStateById(id);
            if (ticketState is null)
                throw new EntityNotFoundException(nameof(TicketState), id);

            var ticketStateDto = _mapper.Map<TicketStateAndTagResponseDto>(ticketState);

            var response = new ApiResponse<TicketStateAndTagResponseDto>(ticketStateDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTicketState(TicketStateRequestDto ticketStateRequestDto)
        {
            var ticketState = _mapper.Map<TicketState>(ticketStateRequestDto);
            await _ticketStateService.InsertTicketState(ticketState);

            var responseDto = new CreationResponseDto(ticketState.Id);

            var response = new ApiResponse<CreationResponseDto>(responseDto);

            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{ticketState.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketState(string id, TicketStateRequestDto ticketStateDto)
        {
            var ticketState = _mapper.Map<TicketState>(ticketStateDto);
            ticketState.Id = id;

            await _ticketStateService.UpdateTicketState(ticketState);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketState(string id)
        {
            await _ticketStateService.DeleteTicketState(id);

            return NoContent();
        }
    }
}
