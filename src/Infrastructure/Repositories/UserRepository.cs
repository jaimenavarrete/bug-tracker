using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BugTrackerContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(BugTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetAll() => await GetUsersQuery().ToListAsync();

        public async Task<User?> GetById(string id) => await GetUsersQuery().FirstOrDefaultAsync(u => u.Id == id);

        public async Task Create(User user)
        {
            var appUser = new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Biography = user.Biography,
                BirthDate = user.BirthDate,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                ProfileImageUrl = user.ProfileImage
            };

            await _userManager.CreateAsync(appUser, user.Password);
        }

        private IQueryable<User> GetUsersQuery() => _context.Users.Select(u => new User
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            UserName = u.UserName,
            Biography = u.Biography,
            BirthDate = u.BirthDate,
            Email = u.Email,
            EmailConfirmed = u.EmailConfirmed,
            PhoneNumber = u.PhoneNumber,
            PhoneNumberConfirmed = u.PhoneNumberConfirmed,
            Address = u.Address,
            ProfileImage = u.ProfileImageUrl
        });
    }
}