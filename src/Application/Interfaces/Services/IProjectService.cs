using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();

        Task<Project?> GetProjectById(string id);

        Task InsertProject(Project project);

        Task UpdateProject(Project project);

        Task DeleteProject(string id);
    }
}
