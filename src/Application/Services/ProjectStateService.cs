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
    }
}
