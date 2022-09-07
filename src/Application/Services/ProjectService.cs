using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetProjects() => await _projectRepository.GetAll();

        public async Task<Project?> GetProjectById(string id) => await _projectRepository.GetById(id);

        public async Task<bool> InsertProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            project.AddCreationInfo(userId);

            var result = await _projectRepository.Insert(project);

            return result;
        }

        public async Task<bool> UpdateProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            
            var currentProject = await _projectRepository.GetById(project.Id);

            if (currentProject is null) return false;

            currentProject.Name = project.Name;
            currentProject.OwnerId = project.OwnerId;
            currentProject.StateId = project.StateId;
            currentProject.StartDate = project.StartDate;
            currentProject.CompletionDate = project.CompletionDate;
            currentProject.GroupId = project.GroupId;
            currentProject.UpdateModificationInfo(userId);

            var result = await _projectRepository.Update(currentProject);

            return result;
        }

        public async Task<bool> DeleteProject(string id)
        {
            return await _projectRepository.Delete(id);
        }
    }
}
