using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
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
    }
}
