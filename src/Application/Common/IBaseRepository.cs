using Domain.Common;

namespace Application.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(string id);

        void Insert(T entity);

        void Delete(T entity);
    }
}
