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

        // Gravity levels
        public async Task<IEnumerable<GravityLevel>> GetGravityLevels()
            => await _unitOfWork.GravityLevelRepository.GetAll();

        public async Task<GravityLevel?> GetGravityLevelById(int id)
            => await _unitOfWork.GravityLevelRepository.GetById(id);

        // Classifications
        public async Task<IEnumerable<Classification>> GetClassifications()
            => await _unitOfWork.ClassificationRepository.GetAll();

        public async Task<Classification?> GetClassificationById(int id)
            => await _unitOfWork.ClassificationRepository.GetById(id);

        // Reproducibility levels
        public async Task<IEnumerable<ReproducibilityLevel>> GetReproducibilityLevels()
            => await _unitOfWork.ReproducibilityLevelRepository.GetAll();

        public async Task<ReproducibilityLevel?> GetReproducibilityLevelById(int id)
            => await _unitOfWork.ReproducibilityLevelRepository.GetById(id);
    }
}