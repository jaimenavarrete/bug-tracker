using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectTagRepository : BaseRepository<ProjectTag>, IProjectTagRepository
    {
        public ProjectTagRepository(BugTrackerContext context) : base(context)
        {
        }

        public async Task<ProjectTag?> GetProjectTagToDeleteById(string id) =>
            await _entity.Include(pt => pt.Projects).FirstOrDefaultAsync(pt => pt.Id == id);
    }
}
