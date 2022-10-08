using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsWithAllEntities();

        Task<Ticket?> GetTicketWithAllEntitiesById(string id);

        Task<Ticket?> GetTicketWithTagsById(string id);
    }
}
