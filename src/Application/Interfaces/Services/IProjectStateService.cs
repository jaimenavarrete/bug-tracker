using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProjectStateService
    {
        Task<IEnumerable<ProjectState>> GetProjectStates();

        Task<ProjectState?> GetProjectStateById(string id);

        Task<ProjectState?> InsertProjectState(ProjectState projectState);
    }
}
