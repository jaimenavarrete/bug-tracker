using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProjectTagService
    {
        Task<IEnumerable<ProjectTag>> GetProjectTags();

        Task<ProjectTag?> GetProjectTagById(string id);

        Task InsertProjectTag(ProjectTag projectTag);

        Task UpdateProjectTag(ProjectTag projectTag);

        Task DeleteProjectTag(string id);
    }
}
