using Application.Common;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly BugTrackerContext _context;
        protected readonly DbSet<T> _entity;

        public BaseRepository(BugTrackerContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll() => await _entity.ToListAsync() ?? Enumerable.Empty<T>();

        public virtual async Task<T?> GetById(string id) => await _entity.FindAsync(id);

        public void Insert(T entity) => _entity.Add(entity);

        public void Delete(T entity) => _entity.Remove(entity);
    }
}
