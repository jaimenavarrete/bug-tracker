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

        public async Task<IEnumerable<Project>> GetProjectsWithRelevantData() =>
            await GetProjectsWithAllEntitiesQuery().ToListAsync() ?? Enumerable.Empty<Project>();

        public async Task<Project?> GetProjectWithRelevantDataById(string id) =>
            await GetProjectsWithAllEntitiesQuery().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Project?> GetProjectWithTagsById(string id) =>
            await _entity.Include(t => t.Tags).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Project?> GetProjectWithChildrenById(string id) =>
            await _entity.Include(p => p.Tags)
                .Include(p => p.TicketTags)
                    .ThenInclude(tt => tt.Tickets)
                        .ThenInclude(t => t.Tags)
                .Include(p => p.TicketStates)
                    .ThenInclude(ts => ts.Tickets)
                        .ThenInclude(t => t.Tags)
                .Include(p => p.Tickets)
                    .ThenInclude(t => t.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);

        private IQueryable<Project> GetProjectsWithAllEntitiesQuery()
        {
            return _entity.Include(t => t.State)
                .Include(t => t.Group)
                .Include(t => t.Tags);
        }
    }
}
