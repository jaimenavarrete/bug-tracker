using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTickets();

        Task<Ticket?> GetTicketById(string id);

        Task<Ticket> InsertTicket(Ticket ticket);

        Task<bool> UpdateTicket(Ticket ticket);

        Task<bool> DeleteTicket(string id);
    }
}
