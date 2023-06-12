using Application.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common
{
    public class LookupBaseRepository<T> : ILookupBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _entity;

        public LookupBaseRepository(BugTrackerContext context)
        {
            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll() => await _entity.ToListAsync();

        public async Task<T?> GetById(int id) => await _entity.FindAsync(id);
    }
}