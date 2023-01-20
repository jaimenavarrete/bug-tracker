using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User?> GetById(string id);

        Task Create(User user);
    }
}