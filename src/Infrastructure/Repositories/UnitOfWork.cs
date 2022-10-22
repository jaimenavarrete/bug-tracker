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
        private readonly IGroupRepository _groupRepository = null!;
        private readonly IProjectRepository _projectRepository = null!;
        private readonly ITicketRepository _ticketRepository = null!;
        private readonly IBaseRepository<ProjectState> _projectStateRepository = null!;
        private readonly IProjectTagRepository _projectTagRepository = null!;
        private readonly IBaseRepository<TicketState> _ticketStateRepository = null!;
        private readonly ITicketTagRepository _ticketTagRepository = null!;

        public UnitOfWork(BugTrackerContext context)
        {
            _context = context;
        }

        public IGroupRepository GroupRepository => _groupRepository ?? new GroupRepository(_context);

        public IProjectRepository ProjectRepository => _projectRepository ?? new ProjectRepository(_context);

        public IBaseRepository<ProjectState> ProjectStateRepository => _projectStateRepository ?? new BaseRepository<ProjectState>(_context);

        public IProjectTagRepository ProjectTagRepository => _projectTagRepository ?? new ProjectTagRepository(_context);

        public ITicketRepository TicketRepository => _ticketRepository ?? new TicketRepository(_context);

        public IBaseRepository<TicketState> TicketStateRepository => _ticketStateRepository ?? new BaseRepository<TicketState>(_context);

        public ITicketTagRepository TicketTagRepository => _ticketTagRepository ?? new TicketTagRepository(_context);

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
