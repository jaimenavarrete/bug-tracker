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

        public async Task<IEnumerable<Project>> GetProjects() => await _unitOfWork.ProjectRepository.GetAll();

        public async Task<Project?> GetProjectById(string id) => await _unitOfWork.ProjectRepository.GetById(id);

        public async Task InsertProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            project.AddCreationInfo(userId);

            _unitOfWork.ProjectRepository.Insert(project);
            await _unitOfWork.CompleteAsync();
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
            var project = await _unitOfWork.ProjectRepository.GetById(id);

            if (project is null)
                throw new EntityNotFoundException("The project you are deleting does not exist.");

            _unitOfWork.ProjectRepository.Delete(project);
            var result = await _unitOfWork.CompleteAsync();

            return result;
        }
    }
}
