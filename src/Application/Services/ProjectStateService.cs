using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

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
    }
}
