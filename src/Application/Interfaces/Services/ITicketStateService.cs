using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITicketStateService
    {
        Task<IEnumerable<TicketState>> GetTicketStates();

        Task<TicketState?> GetTicketStateById(string id);

        Task<TicketState?> InsertTicketState(TicketState ticketState);

        Task<bool> UpdateTicketState(TicketState ticketState);

        Task<bool> DeleteTicketState(string id);
    }
}
