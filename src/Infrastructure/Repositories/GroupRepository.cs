using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(BugTrackerContext context) : base(context)
        {
        }

        public async Task<Group?> GetGroupWithChildrenById(string id) =>
            await _entity.Include(g => g.ProjectStates)
                .Include(t => t.ProjectTags)
                .Include(t => t.Projects).FirstOrDefaultAsync(g => g.Id == id);
    }
}
