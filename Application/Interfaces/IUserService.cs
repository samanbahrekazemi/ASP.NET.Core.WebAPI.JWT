using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        IEnumerable<User> GetAllUsers();

    }
}
