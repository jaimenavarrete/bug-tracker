using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    //[Authorize]
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
            var ticketsDto = _mapper.Map<IEnumerable<TicketMiniResponseDto>>(tickets);

            var response = new ApiResponse<IEnumerable<TicketMiniResponseDto>>(ticketsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(string id)
        {
            var ticket = await _ticketService.GetTicketById(id);

            if (ticket is null)
                throw new EntityNotFoundException(nameof(Ticket), id);

            var ticketDto = _mapper.Map<TicketResponseDto>(ticket);

            var response = new ApiResponse<TicketResponseDto>(ticketDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTicket(TicketRequestDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketService.InsertTicket(ticket);

            var responseDto = new CreationResponseDto(ticket.Id);

            var response = new ApiResponse<CreationResponseDto>(responseDto);

            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{ticket.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(string id, TicketRequestDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            ticket.Id = id;

            await _ticketService.UpdateTicket(ticket);

            return NoContent();
        }

        [HttpPut("{id}/completion")]
        public async Task<IActionResult> SetTicketCompletion(string id, SetTicketCompletionRequestDto completionDto)
        {
            await _ticketService.SetTicketCompletion(id, completionDto.IsCompleted);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            await _ticketService.DeleteTicket(id);

            return NoContent();
        }
    }
}
