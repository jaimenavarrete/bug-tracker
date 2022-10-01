using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsWithEntities();

        Task<Ticket?> GetTicketWithEntitiesById(string id);

        Task<Ticket?> GetTicketWithTagsById(string id);
    }
}
