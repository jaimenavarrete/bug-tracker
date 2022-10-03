using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

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
    }
}
