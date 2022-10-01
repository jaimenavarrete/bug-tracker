using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups();

        Task<Group?> GetGroupById(string id);
    }
}
