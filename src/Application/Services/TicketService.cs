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

        public async Task<IEnumerable<Ticket>> GetTickets() => await _unitOfWork.TicketRepository.GetAll();

        public async Task<Ticket?> GetTicketById(string id) => await _unitOfWork.TicketRepository.GetById(id);

        public async Task InsertTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTicket(string id)
        {
            throw new NotImplementedException();
        }
    }
}
