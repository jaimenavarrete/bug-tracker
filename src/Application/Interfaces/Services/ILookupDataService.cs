using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ILookupDataService
    {
        Task<IEnumerable<GravityLevel>> GetGravityLevels();

        Task<GravityLevel?> GetGravityLevelById(int id);

        Task<IEnumerable<Classification>> GetClassifications();

        Task<Classification?> GetClassificationById(int id);

        Task<IEnumerable<ReproducibilityLevel>> GetReproducibilityLevels();

        Task<ReproducibilityLevel?> GetReproducibilityLevelById(int id);
    }
}