using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetProjectsWithRelevantData();

        Task<Project?> GetProjectWithRelevantDataById(string id);

        Task<Project?> GetProjectWithTagsById(string id);

        Task<Project?> GetProjectWithChildrenById(string id);
    }
}
