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

        public override async Task<IEnumerable<Project>> GetAll() =>
            await GetProjectsQuery().ToListAsync() ?? Enumerable.Empty<Project>();

        public override async Task<Project?> GetById(string id) =>
            await GetProjectsQuery().Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Project?> GetByTicketsPrefix(string ticketsPrefix) =>
            await _entity.FirstOrDefaultAsync(p => p.TicketsPrefix == ticketsPrefix);

        private IQueryable<Project> GetProjectsQuery()
            => _entity.Include(p => p.State).Include(p => p.Group);
    }
}
