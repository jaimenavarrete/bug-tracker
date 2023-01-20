using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User?> GetUserById(string id);

        Task CreateUser(User user);
    }
}
