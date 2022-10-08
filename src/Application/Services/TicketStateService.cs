using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class TicketStateService : ITicketStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketStateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TicketState>> GetTicketStates() => await _unitOfWork.TicketStateRepository.GetAll();

        public async Task<TicketState?> GetTicketStateById(string id) => await _unitOfWork.TicketStateRepository.GetById(id);

        public async Task InsertTicketState(TicketState ticketState)
        {
            var userId = Guid.NewGuid().ToString();
            ticketState.AddCreationInfo(userId);

            await ValidateEntityValues(ticketState);

            _unitOfWork.TicketStateRepository.Insert(ticketState);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateTicketState(TicketState ticketState)
        {
            var userId = Guid.NewGuid().ToString();

            var currentTicketState = await _unitOfWork.TicketStateRepository.GetById(ticketState.Id);

            if (currentTicketState is null)
                throw new EntityNotFoundException(nameof(TicketState), ticketState.Id);

            await ValidateEntityValues(ticketState);

            currentTicketState.Name = ticketState.Name;
            currentTicketState.ProjectId = ticketState.ProjectId;
            currentTicketState.ColorHexCode = ticketState.ColorHexCode;
            currentTicketState.UpdateModificationInfo(userId);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteTicketState(string id)
        {
            var ticketState = await _unitOfWork.TicketStateRepository.GetById(id);

            if (ticketState is null)
                throw new EntityNotFoundException(nameof(TicketState), id);

            _unitOfWork.TicketStateRepository.Delete(ticketState);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ValidateEntityValues(TicketState ticketState)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(ticketState.ProjectId);
            if (project is null)
                throw new EntityValueNotFoundException(nameof(Project), ticketState.ProjectId);
        }
    }
}
