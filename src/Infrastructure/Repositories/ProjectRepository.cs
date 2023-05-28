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
            await GetProjectsQuery().Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);

        private IQueryable<Project> GetProjectsQuery()
            => _entity.Include(p => p.State).Include(p => p.Group);
    }
}
