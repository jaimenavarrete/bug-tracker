using Application.Common;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BugTrackerContext _context;
        private readonly IBaseRepository<Project> _projectRepository = null!;
        private readonly ITicketRepository _ticketRepository = null!;

        public UnitOfWork(BugTrackerContext context)
        {
            _context = context;
        }

        public IBaseRepository<Project> ProjectRepository => _projectRepository ?? new BaseRepository<Project>(_context);

        public ITicketRepository TicketRepository => _ticketRepository ?? new TicketRepository(_context);

        public bool Complete() => _context.SaveChanges() > 0;

        public async Task<bool> CompleteAsync() => await _context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            if (_context is null) 
                return;

            _context.Dispose();
        }
    }
}
