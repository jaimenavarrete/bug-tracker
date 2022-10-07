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

        public async Task InsertProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            project.AddCreationInfo(userId);

            await ValidateEntityValues(project);

            _unitOfWork.ProjectRepository.Insert(project);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            
            var currentProject = await _unitOfWork.ProjectRepository.GetById(project.Id);

            if (currentProject is null)
                throw new EntityNotFoundException(nameof(Project), project.Id);

            await ValidateEntityValues(project);

            currentProject.Name = project.Name;
            currentProject.Description = project.Description;
            currentProject.TicketsPrefix = project.TicketsPrefix;
            currentProject.OwnerId = project.OwnerId;
            currentProject.StateId = project.StateId;
            currentProject.StartDate = project.StartDate;
            currentProject.CompletionDate = project.CompletionDate;
            currentProject.GroupId = project.GroupId;
            currentProject.UpdateModificationInfo(userId);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProject(string id)
        {
            var project = await _unitOfWork.ProjectRepository.GetProjectWithTagsById(id);

            if (project is null)
                throw new EntityNotFoundException(nameof(Project), id);

            // Remove the tags assigned to this project
            project.Tags = Enumerable.Empty<ProjectTag>();

            _unitOfWork.ProjectRepository.Delete(project);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ValidateEntityValues(Project project)
        {
            var state = await _unitOfWork.ProjectStateRepository.GetById(project.StateId);
            var group = await _unitOfWork.GroupRepository.GetById(project.GroupId ?? string.Empty);

            if (state is null)
                throw new EntityValueNotFoundException(nameof(ProjectState), project.StateId);

            if (group is null && project.GroupId is not null)
                throw new EntityValueNotFoundException(nameof(Group), project.GroupId);
        }
    }
}
