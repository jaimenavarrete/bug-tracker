using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetProjectsWithEntities();

        Task<Project?> GetProjectWithEntitiesById(string id);

        Task<Project?> GetProjectWithTagsById(string id);
    }
}
