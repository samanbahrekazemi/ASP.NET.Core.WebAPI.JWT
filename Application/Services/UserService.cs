using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _context;

        public UserService(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include(a => a.UserRoles).ThenInclude(a => a.Role).AsEnumerable();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(a => a.UserRoles).ThenInclude(a => a.Role).ToListAsync();
        }
    }
}
