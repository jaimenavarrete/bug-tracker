using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ticket>> GetTickets() => await _unitOfWork.TicketRepository.GetTicketsWithEntities();

        public async Task<Ticket?> GetTicketById(string id) => await _unitOfWork.TicketRepository.GetTicketWithEntitiesById(id);

        public async Task<Ticket> InsertTicket(Ticket ticket)
        {
            var userId = Guid.NewGuid().ToString();
            ticket.AddCreationInfo(userId);

            _unitOfWork.TicketRepository.Insert(ticket);
            var result = await _unitOfWork.CompleteAsync();

            if(!result)
                throw new EntityNotFoundException("The ticket could not be created.");

            return await _unitOfWork.TicketRepository.GetTicketWithEntitiesById(ticket.Id) ?? ticket;
        }

        public async Task<bool> UpdateTicket(Ticket ticket)
        {
            var currentTicket = await _unitOfWork.TicketRepository.GetById(ticket.Id);

            if (currentTicket is null)
                throw new EntityNotFoundException("The ticket you are modifying does not exist.");

            currentTicket.Name = ticket.Name;
            currentTicket.Description = ticket.Description;
            currentTicket.SubmitterId = ticket.SubmitterId;
            currentTicket.StateId = ticket.StateId;
            currentTicket.AssignedUserId = ticket.AssignedUserId;
            currentTicket.CompletionDate = ticket.CompletionDate;
            currentTicket.GravityId = ticket.GravityId;
            currentTicket.ReproducibilityId = ticket.ReproducibilityId;
            currentTicket.ClassificationId = ticket.ClassificationId;
            currentTicket.ProjectId = ticket.ProjectId;

            var result = await _unitOfWork.CompleteAsync();

            return result;
        }

        public async Task<bool> DeleteTicket(string id)
        {
            var ticket = await _unitOfWork.TicketRepository.GetTicketWithTagsById(id);

            if (ticket is null)
                throw new EntityNotFoundException("The ticket you are deleting does not exist.");

            // Remove the tags assigned to this ticket
            ticket.Tags = Enumerable.Empty<TicketTag>();

            _unitOfWork.TicketRepository.Delete(ticket);
            var result = await _unitOfWork.CompleteAsync();

            return result;
        }
    }
}
