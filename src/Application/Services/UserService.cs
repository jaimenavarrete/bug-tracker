using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

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

        public async Task<User?> GetUserById(string id) => await _unitOfWork.UserRepository.GetById(id);

        public async Task<User?> GetUserByCredentials(string email, string password) =>
            await _unitOfWork.UserRepository.GetByCredentials(email, password);

        public async Task CreateUser(User user)
        {
            await _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUser(string id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            if (user is null)
                throw new EntityNotFoundException(nameof(User), id);

            await _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
