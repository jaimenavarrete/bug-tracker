using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Project>> GetProjects() => await _unitOfWork.ProjectRepository.GetProjectsWithEntities();

        public async Task<Project?> GetProjectById(string id) => await _unitOfWork.ProjectRepository.GetProjectWithEntitiesById(id);

        public async Task<Project?> InsertProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            project.AddCreationInfo(userId);

            _unitOfWork.ProjectRepository.Insert(project);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                throw new EntityNotFoundException("The project could not be created");

            return await _unitOfWork.ProjectRepository.GetProjectWithEntitiesById(project.Id);
        }

        public async Task<bool> UpdateProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            
            var currentProject = await _unitOfWork.ProjectRepository.GetById(project.Id);

            if (currentProject is null)
                throw new EntityNotFoundException("The project you are modifying does not exist.");

            currentProject.Name = project.Name;
            currentProject.Description = project.Description;
            currentProject.TicketsPrefix = project.TicketsPrefix;
            currentProject.OwnerId = project.OwnerId;
            currentProject.StateId = project.StateId;
            currentProject.StartDate = project.StartDate;
            currentProject.CompletionDate = project.CompletionDate;
            currentProject.GroupId = project.GroupId;
            currentProject.UpdateModificationInfo(userId);

            var result = await _unitOfWork.CompleteAsync();

            return result;
        }

        public async Task<bool> DeleteProject(string id)
        {
            var project = await _unitOfWork.ProjectRepository.GetProjectWithTagsById(id);

            if (project is null)
                throw new EntityNotFoundException("The project you are deleting does not exist.");

            // Remove the tags assigned to this project
            project.Tags = Enumerable.Empty<ProjectTag>();

            _unitOfWork.ProjectRepository.Delete(project);
            var result = await _unitOfWork.CompleteAsync();

            return result;
        }
    }
}
