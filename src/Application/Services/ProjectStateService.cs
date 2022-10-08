using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class ProjectStateService : IProjectStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectStateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectState>> GetProjectStates() => await _unitOfWork.ProjectStateRepository.GetAll();

        public async Task<ProjectState?> GetProjectStateById(string id) => await _unitOfWork.ProjectStateRepository.GetById(id);

        public async Task InsertProjectState(ProjectState projectState)
        {
            var userId = Guid.NewGuid().ToString();
            projectState.AddCreationInfo(userId);

            await ValidateEntityValues(projectState);

            _unitOfWork.ProjectStateRepository.Insert(projectState);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateProjectState(ProjectState projectState)
        {
            var userId = Guid.NewGuid().ToString();

            var currentProjectState = await _unitOfWork.ProjectStateRepository.GetById(projectState.Id);

            if (currentProjectState is null)
                throw new EntityNotFoundException(nameof(ProjectState), projectState.Id);

            await ValidateEntityValues(projectState);

            currentProjectState.Name = projectState.Name;
            currentProjectState.GroupId = projectState.GroupId;
            currentProjectState.ColorHexCode = projectState.ColorHexCode;
            currentProjectState.UpdateModificationInfo(userId);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProjectState(string id)
        {
            var projectState = await _unitOfWork.ProjectStateRepository.GetById(id);

            if (projectState is null)
                throw new EntityNotFoundException(nameof(ProjectState), id);

            _unitOfWork.ProjectStateRepository.Delete(projectState);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ValidateEntityValues(ProjectState projectState)
        {
            var group = await _unitOfWork.GroupRepository.GetById(projectState.GroupId);
            if(group is null)
                throw new EntityValueNotFoundException(nameof(Group), projectState.GroupId);
        }
    }
}
