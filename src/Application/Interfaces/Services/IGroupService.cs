using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups();

        Task<Group?> GetGroupById(string id);

        Task<Group?> InsertGroup(Group project);

        Task<bool> UpdateGroup(Group project);

        Task<bool> DeleteGroup(string id);
    }
}
