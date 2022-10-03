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

        public async Task<TicketState?> InsertTicketState(TicketState ticketState)
        {
            var userId = Guid.NewGuid().ToString();
            ticketState.AddCreationInfo(userId);

            _unitOfWork.TicketStateRepository.Insert(ticketState);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                throw new EntityNotFoundException("The ticket state could not be created");

            return await _unitOfWork.TicketStateRepository.GetById(ticketState.Id);
        }

        public async Task<bool> UpdateTicketState(TicketState ticketState)
        {
            var userId = Guid.NewGuid().ToString();

            var currentTicketState = await _unitOfWork.TicketStateRepository.GetById(ticketState.Id);

            if (currentTicketState is null)
                throw new EntityNotFoundException("The ticket state you are modifying does not exist.");

            currentTicketState.Name = ticketState.Name;
            currentTicketState.ProjectId = ticketState.ProjectId;
            currentTicketState.ColorHexCode = ticketState.ColorHexCode;
            currentTicketState.UpdateModificationInfo(userId);

            var result = await _unitOfWork.CompleteAsync();

            return result;
        }

        public async Task<bool> DeleteTicketState(string id)
        {
            var ticketState = await _unitOfWork.TicketStateRepository.GetById(id);

            if (ticketState is null)
                throw new EntityNotFoundException("The ticket state you are deleting does not exist.");

            _unitOfWork.TicketStateRepository.Delete(ticketState);
            var result = await _unitOfWork.CompleteAsync();

            return result;
        }
    }
}
