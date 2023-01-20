using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User?> GetById(string id);

        Task<User?> GetByCredentials(string email, string password);

        Task Create(User user);
    }
}