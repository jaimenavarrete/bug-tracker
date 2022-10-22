using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ITicketTagRepository : IBaseRepository<TicketTag>
    {
        Task<TicketTag?> GetTicketTagToDeleteById(string id);
    }
}
