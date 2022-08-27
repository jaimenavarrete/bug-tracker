using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();

        Task<Project> GetById(string id);

        Task<Project> Insert(Project project);

        Task<Project> Update(Project project);

        Task<bool> Delete(string id);
    }
}
