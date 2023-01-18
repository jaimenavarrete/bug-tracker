using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(BugTrackerContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Project>> GetAll() =>
            await GetProjectsQuery().ToListAsync() ?? Enumerable.Empty<Project>();

        public override async Task<Project?> GetById(string id) =>
            await GetProjectsQuery().FirstOrDefaultAsync(p => p.Id == id);

        private IQueryable<Project> GetProjectsQuery()
        {
            return _entity.Include(t => t.State)
                .Include(t => t.Group)
                .Include(t => t.Tags);
        }
    }
}
