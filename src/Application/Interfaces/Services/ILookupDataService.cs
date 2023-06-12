
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ILookupDataService
    {
        Task<IEnumerable<GravityLevel>> GetGravityLevels();

        Task<IEnumerable<Classification>> GetClassifications();

        Task<IEnumerable<ReproducibilityLevel>> GetReproducibilityLevels();
    }
}