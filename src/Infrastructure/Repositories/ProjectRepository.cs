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

        public async Task<IEnumerable<Project>> GetProjectsWithEntities() =>
            await GetProjectsWithEntitiesQuery().ToListAsync() ?? Enumerable.Empty<Project>();

        public async Task<Project?> GetProjectWithEntitiesById(string id) =>
            await GetProjectsWithEntitiesQuery().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Project?> GetProjectWithTagsById(string id) =>
            await _entity.Include(t => t.Tags).FirstOrDefaultAsync(p => p.Id == id);

        private IQueryable<Project> GetProjectsWithEntitiesQuery()
        {
            return _entity.Include(t => t.State)
                .Include(t => t.Group)
                .Include(t => t.Tags);
        }
    }
}
