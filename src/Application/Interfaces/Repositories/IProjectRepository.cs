using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();

        Task<Project?> GetById(string id);

        Task<bool> Insert(Project project);

        Task<bool> Update(Project project);

        Task<bool> Delete(string id);
    }
}
