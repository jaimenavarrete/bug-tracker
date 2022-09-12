using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

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

        public async Task InsertProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            project.AddCreationInfo(userId);

            await _projectRepository.Insert(project);
        }

        public async Task<bool> UpdateProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            
            var currentProject = await _projectRepository.GetById(project.Id);

            if (currentProject is null) 
                throw new EntityNotFoundException("The project your are modifying does not exist.");

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
            var project = await _projectRepository.GetById(id);

            if (project is null)
                throw new EntityNotFoundException("The project your are deleting does not exist.");

            return await _projectRepository.Delete(project);
        }
    }
}
