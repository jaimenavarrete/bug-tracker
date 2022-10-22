using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsWithRelevantData();

        Task<Ticket?> GetTicketWithRelevantDataById(string id);

        Task<Ticket?> GetTicketWithTagsById(string id);

        Task<Ticket?> GetTicketWithChildrenById(string id);
    }
}
