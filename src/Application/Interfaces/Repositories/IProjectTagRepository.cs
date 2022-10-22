using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IProjectTagRepository : IBaseRepository<ProjectTag>
    {
        Task<ProjectTag?> GetProjectTagToDeleteById(string id);
    }
}
