using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<Group?> GetGroupWithChildrenById(string id);
    }
}
