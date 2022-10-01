using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(BugTrackerContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticket>> GetTicketsWithAllEntities() => 
            await GetTicketsWithEntitiesQuery().ToListAsync() ?? Enumerable.Empty<Ticket>();

        public async Task<Ticket?> GetTicketWithAllEntitiesById(string id) => 
            await GetTicketsWithEntitiesQuery().FirstOrDefaultAsync(t => t.Id == id);

        public async Task<Ticket?> GetTicketWithTagsById(string id) =>
            await _entity.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);

        private IQueryable<Ticket> GetTicketsWithEntitiesQuery()
        {
            return _entity.Include(t => t.State)
                .Include(t => t.Tags)
                .Include(t => t.Classification)
                .Include(t => t.Gravity)
                .Include(t => t.Reproducibility);
        }
    }
}
