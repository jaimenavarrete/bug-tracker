using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class LookupDataService : ILookupDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LookupDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GravityLevel>> GetGravityLevels()
            => await _unitOfWork.GravityLevelRepository.GetAll();

        public async Task<IEnumerable<Classification>> GetClassifications()
            => await _unitOfWork.ClassificationRepository.GetAll();

        public async Task<IEnumerable<ReproducibilityLevel>> GetReproducibilityLevels()
            => await _unitOfWork.ReproducibilityLevelRepository.GetAll();
    }
}