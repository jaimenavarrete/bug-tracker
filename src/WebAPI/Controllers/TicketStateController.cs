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
            var ticketStatesDto = _mapper.Map<IEnumerable<TicketStateResponseDto>>(ticketStates);

            var response = new ApiResponse<IEnumerable<TicketStateResponseDto>>(ticketStatesDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketStateById(string id)
        {
            var ticketState = await _ticketStateService.GetTicketStateById(id);
            if (ticketState is null)
                throw new EntityNotFoundException("The ticket state you are looking for does not exist.");

            var ticketStateDto = _mapper.Map<TicketStateResponseDto>(ticketState);

            var response = new ApiResponse<TicketStateResponseDto>(ticketStateDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTicketState(TicketStateRequestDto ticketStateRequestDto)
        {
            var ticketState = _mapper.Map<TicketState>(ticketStateRequestDto);
            ticketState = await _ticketStateService.InsertTicketState(ticketState);

            var responseDto = _mapper.Map<TicketStateResponseDto>(ticketState);

            var response = new ApiResponse<TicketStateResponseDto>(responseDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketState(string id, TicketStateRequestDto ticketStateDto)
        {
            var ticketState = _mapper.Map<TicketState>(ticketStateDto);
            ticketState.Id = id;

            var result = await _ticketStateService.UpdateTicketState(ticketState);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketState(string id)
        {
            var result = await _ticketStateService.DeleteTicketState(id);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
