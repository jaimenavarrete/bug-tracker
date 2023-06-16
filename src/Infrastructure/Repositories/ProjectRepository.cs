using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(BugTrackerContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Project>> GetAll()
            => await GetProjectsWithTicketsCountingQuery()
                .ToListAsync() ?? Enumerable.Empty<Project>();

        public override async Task<Project?> GetById(string id)
            => await GetProjectsWithTicketsCountingQuery()
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Project?> GetByTicketsPrefix(string ticketsPrefix)
            => await _entity.FirstOrDefaultAsync(p => p.TicketsPrefix == ticketsPrefix);

        private IQueryable<Project> GetProjectsWithTicketsCountingQuery()
            => GetProjectsQuery()
                .Select(p => new Project()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    TicketsPrefix = p.TicketsPrefix,
                    OwnerId = p.OwnerId,
                    State = p.State,
                    StartDate = p.StartDate,
                    CompletionDate = p.CompletionDate,
                    Group = p.Group,
                    CompletedTicketsCount = p.Tickets.Where(t => t.IsCompleted).Count(),
                    PendingTicketsCount = p.Tickets.Where(t => !t.IsCompleted).Count(),
                    Tags = p.Tags.ToList(),
                    CreationDate = p.CreationDate,
                    CreatedBy = p.CreatedBy,
                    LastModificationDate = p.LastModificationDate,
                    ModifiedBy = p.ModifiedBy
                });

        private IQueryable<Project> GetProjectsQuery()
            => _entity.Include(p => p.State)
                .Include(p => p.Group)
                .Include(p => p.Tags)
                .Include(p => p.Tickets);
    }
}
