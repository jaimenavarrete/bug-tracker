using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetTickets();
            var ticketsDto = _mapper.Map<IEnumerable<TicketResponseDto>>(tickets);

            var response = new ApiResponse<IEnumerable<TicketResponseDto>>(ticketsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTickets(string id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            var ticketDto = _mapper.Map<TicketResponseDto>(ticket);

            var response = new ApiResponse<TicketResponseDto>(ticketDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTicket(TicketRequestDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            ticket = await _ticketService.InsertTicket(ticket);

            var responseDto = _mapper.Map<TicketResponseDto>(ticket);

            var response = new ApiResponse<TicketResponseDto>(responseDto);

            return Ok(response);
        }
    }
}
