using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);

        Task DeleteUserByEmailAsync(string email);

        Task<User> GetUserByEmailAsync(string email);

        Task<List<User>> GetUsersAsync();

        Task MakeFriendsAsync(string userId, string friendId);

        Task UnfriendAsync(string userId, string friendId);

        Task UpdateAsync(User user);
    }
}