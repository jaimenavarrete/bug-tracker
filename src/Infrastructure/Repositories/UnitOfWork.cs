using Application.Common;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BugTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IBaseRepository<Group> _groupRepository = null!;
        private readonly IProjectRepository _projectRepository = null!;
        private readonly IBaseRepository<Ticket> _ticketRepository = null!;
        private readonly IBaseRepository<ProjectState> _projectStateRepository = null!;
        private readonly IBaseRepository<ProjectTag> _projectTagRepository = null!;
        private readonly IBaseRepository<TicketState> _ticketStateRepository = null!;
        private readonly IBaseRepository<TicketTag> _ticketTagRepository = null!;
        private readonly IUserRepository _userRepository = null!;
        private readonly ILookupBaseRepository<GravityLevel> _gravityLevelRepository = null!;
        private readonly ILookupBaseRepository<Classification> _classificationRepository = null!;
        private readonly ILookupBaseRepository<ReproducibilityLevel> _reproducibilityLevelRepository = null!;

        public UnitOfWork(BugTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IBaseRepository<Group> GroupRepository
            => _groupRepository ?? new BaseRepository<Group>(_context);

        public IProjectRepository ProjectRepository
            => _projectRepository ?? new ProjectRepository(_context);

        public IBaseRepository<ProjectState> ProjectStateRepository
            => _projectStateRepository ?? new BaseRepository<ProjectState>(_context);

        public IBaseRepository<ProjectTag> ProjectTagRepository
            => _projectTagRepository ?? new BaseRepository<ProjectTag>(_context);

        public IBaseRepository<Ticket> TicketRepository
            => _ticketRepository ?? new TicketRepository(_context);

        public IBaseRepository<TicketState> TicketStateRepository
            => _ticketStateRepository ?? new BaseRepository<TicketState>(_context);

        public IBaseRepository<TicketTag> TicketTagRepository
            => _ticketTagRepository ?? new BaseRepository<TicketTag>(_context);

        public IUserRepository UserRepository
            => _userRepository ?? new UserRepository(_context, _userManager);

        public ILookupBaseRepository<GravityLevel> GravityLevelRepository
                => _gravityLevelRepository ?? new LookupBaseRepository<GravityLevel>(_context);

        public ILookupBaseRepository<Classification> ClassificationRepository
                => _classificationRepository ?? new LookupBaseRepository<Classification>(_context);

        public ILookupBaseRepository<ReproducibilityLevel> ReproducibilityLevelRepository
                => _reproducibilityLevelRepository ?? new LookupBaseRepository<ReproducibilityLevel>(_context);

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
