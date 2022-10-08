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

        public async Task<IEnumerable<Ticket>> GetTickets() => await _unitOfWork.TicketRepository.GetTicketsWithAllEntities();

        public async Task<Ticket?> GetTicketById(string id) => await _unitOfWork.TicketRepository.GetTicketWithAllEntitiesById(id);

        public async Task InsertTicket(Ticket ticket)
        {
            var userId = Guid.NewGuid().ToString();
            ticket.AddCreationInfo(userId);

            await ValidateEntityValues(ticket);

            _unitOfWork.TicketRepository.Insert(ticket);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            var currentTicket = await _unitOfWork.TicketRepository.GetById(ticket.Id);

            if (currentTicket is null)
                throw new EntityNotFoundException(nameof(Ticket), ticket.Id);

            await ValidateEntityValues(ticket);

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

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteTicket(string id)
        {
            var ticket = await _unitOfWork.TicketRepository.GetTicketWithTagsById(id);

            if (ticket is null)
                throw new EntityNotFoundException(nameof(Ticket), id);

            // Remove the tags assigned to this ticket
            ticket.Tags = Enumerable.Empty<TicketTag>();

            _unitOfWork.TicketRepository.Delete(ticket);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ValidateEntityValues(Ticket ticket)
        {
            var state = await _unitOfWork.TicketStateRepository.GetById(ticket.StateId);
            if (state is null)
                throw new EntityValueNotFoundException(nameof(TicketState), ticket.StateId);

            var project = await _unitOfWork.ProjectRepository.GetById(ticket.ProjectId ?? string.Empty);
            if (project is null && ticket.ProjectId is not null)
                throw new EntityValueNotFoundException(nameof(Project), ticket.ProjectId);
        }
    }
}
