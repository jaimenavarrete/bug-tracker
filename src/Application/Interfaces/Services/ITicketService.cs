using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTickets();

        Task<Ticket?> GetTicketById(string id);

        Task InsertTicket(Ticket ticket);

        Task UpdateTicket(Ticket ticket);

        Task DeleteTicket(string id);
    }
}
