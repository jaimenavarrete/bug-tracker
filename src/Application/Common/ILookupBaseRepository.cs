namespace Application.Common
{
    public interface ILookupBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(string id);

    }
}