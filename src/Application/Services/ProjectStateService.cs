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

        public async Task<ProjectState?> InsertProjectState(ProjectState projectState)
        {
            var userId = Guid.NewGuid().ToString();
            projectState.AddCreationInfo(userId);

            _unitOfWork.ProjectStateRepository.Insert(projectState);
            var result = await _unitOfWork.CompleteAsync();

            if(!result)
                throw new EntityNotFoundException("The project state could not be created");

            return await _unitOfWork.ProjectStateRepository.GetById(projectState.Id);
        }

        public async Task<bool> UpdateProjectState(ProjectState projectState)
        {
            var userId = Guid.NewGuid().ToString();

            var currentProjectState = await _unitOfWork.ProjectStateRepository.GetById(projectState.Id);

            if (currentProjectState is null)
                throw new EntityNotFoundException("The project state you are modifying does not exist.");

            currentProjectState.Name = projectState.Name;
            currentProjectState.GroupId = projectState.GroupId;
            currentProjectState.ColorHexCode = projectState.ColorHexCode;
            currentProjectState.UpdateModificationInfo(userId);

            var result = await _unitOfWork.CompleteAsync();

            return result;
        }

        public async Task<bool> DeleteProjectState(string id)
        {
            var projectState = await _unitOfWork.ProjectStateRepository.GetById(id);

            if (projectState is null)
                throw new EntityNotFoundException("The project state you are deleting does not exist.");

            _unitOfWork.ProjectStateRepository.Delete(projectState);
            var result = await _unitOfWork.CompleteAsync();

            return result;
        }
    }
}
