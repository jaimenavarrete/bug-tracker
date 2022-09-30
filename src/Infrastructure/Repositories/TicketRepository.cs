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

        public override async Task<IEnumerable<Ticket>> GetAll() => 
            await GetAllTicketsQuery().ToListAsync() ?? Enumerable.Empty<Ticket>();

        public override async Task<Ticket?> GetById(string id) => 
            await GetAllTicketsQuery().FirstOrDefaultAsync(t => t.Id == id);

        private IQueryable<Ticket> GetAllTicketsQuery()
        {
            return _entity.Include(t => t.State)
                .Include(t => t.Tags)
                .Include(t => t.Classification)
                .Include(t => t.Gravity)
                .Include(t => t.Reproducibility);
        }
    }
}
