using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProjectStateService
    {
        Task<IEnumerable<ProjectState>> GetProjectStates();

        Task<ProjectState?> GetProjectStateById(string id);

        Task InsertProjectState(ProjectState projectState);

        Task UpdateProjectState(ProjectState projectState);

        Task DeleteProjectState(string id);
    }
}
