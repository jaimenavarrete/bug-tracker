using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();

        Task<Project?> GetProjectById(string id);

        Task InsertProject(Project project);

        Task<bool> UpdateProject(Project project);

        Task<bool> DeleteProject(string id);
    }
}
