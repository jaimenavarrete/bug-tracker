using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TicketTagRepository : BaseRepository<TicketTag>, ITicketTagRepository
    {
        public TicketTagRepository(BugTrackerContext context) : base(context)
        {
        }

        public async Task<TicketTag?> GetTicketTagToDeleteById(string id) =>
            await _entity.Include(tt => tt.Tickets).FirstOrDefaultAsync(tt => tt.Id == id);
    }
}
