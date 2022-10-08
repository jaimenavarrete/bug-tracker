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
        private readonly IBaseRepository<Group> _groupRepository = null!;
        private readonly IProjectRepository _projectRepository = null!;
        private readonly ITicketRepository _ticketRepository = null!;
        private readonly IBaseRepository<ProjectState> _projectStateRepository = null!;
        private readonly IBaseRepository<ProjectTag> _projectTagRepository = null!;
        private readonly IBaseRepository<TicketState> _ticketStateRepository = null!;
        private readonly IBaseRepository<TicketTag> _ticketTagRepository = null!;

        public UnitOfWork(BugTrackerContext context)
        {
            _context = context;
        }

        public IBaseRepository<Group> GroupRepository => _groupRepository ?? new BaseRepository<Group>(_context);

        public IProjectRepository ProjectRepository => _projectRepository ?? new ProjectRepository(_context);

        public IBaseRepository<ProjectState> ProjectStateRepository => _projectStateRepository ?? new BaseRepository<ProjectState>(_context);

        public IBaseRepository<ProjectTag> ProjectTagRepository => _projectTagRepository ?? new BaseRepository<ProjectTag>(_context);

        public ITicketRepository TicketRepository => _ticketRepository ?? new TicketRepository(_context);

        public IBaseRepository<TicketState> TicketStateRepository => _ticketStateRepository ?? new BaseRepository<TicketState>(_context);

        public IBaseRepository<TicketTag> TicketTagRepository => _ticketTagRepository ?? new BaseRepository<TicketTag>(_context);

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
