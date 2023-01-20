using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetUsers() => await _unitOfWork.UserRepository.GetAll();

        public async Task<User?> GetUserById(string id) => await _unitOfWork.UserRepository.GetUserById(id);

        public async Task CreateUser(User user)
        {
            await _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
