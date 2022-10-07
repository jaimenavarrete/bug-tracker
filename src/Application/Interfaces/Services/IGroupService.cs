using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups();

        Task<Group?> GetGroupById(string id);

        Task InsertGroup(Group project);

        Task UpdateGroup(Group project);

        Task DeleteGroup(string id);
    }
}
