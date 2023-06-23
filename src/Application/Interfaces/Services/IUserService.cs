using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User?> GetUserById(string id);

        Task<User?> GetUserByCredentials(string email, string password);

        Task CreateUser(User user);

        Task DeleteUser(string id);
    }
}
