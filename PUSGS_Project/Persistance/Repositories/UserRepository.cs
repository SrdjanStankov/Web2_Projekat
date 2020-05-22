using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public Task<List<User>> GetUsersAsync()
        {
            return context.User.Include(u => u.Friends).ToListAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return context.User.Include(u => u.Friends).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> AddAsync(User user)
        {
            if (await context.User.AnyAsync(u => u.Email == user.Email))
            {
                return false;
            }

            await context.User.AddAsync(user);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteUserByEmailAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            context.User.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var dbUser = await GetUserByEmailAsync(user.Email);

            if (!string.IsNullOrWhiteSpace(user.City))
                dbUser.City = user.City;

            if (!string.IsNullOrWhiteSpace(user.Name))
                dbUser.Name = user.Name;

            if (!string.IsNullOrWhiteSpace(user.LastName))
                dbUser.LastName = user.LastName;

            if (!string.IsNullOrWhiteSpace(user.Phone))
                dbUser.Phone = user.Phone;

            if (!string.IsNullOrWhiteSpace(user.Password))
                dbUser.Password = user.Password;

            await context.SaveChangesAsync();
        }

        public async Task MakeFriendsAsync(string userId, string friendId)
        {
            var user = await GetUserByEmailAsync(userId);
            var friend = await GetUserByEmailAsync(friendId);

            if (!user.Friends.Any(f => f.Email == friend.Email))
            {
                user.Friends.Add(friend);
                friend.Friends.Add(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task UnfriendAsync(string userId, string friendId)
        {
            var user = await GetUserByEmailAsync(userId);
            var friend = await GetUserByEmailAsync(friendId);

            user.Friends.Remove(friend);
            friend.Friends.Remove(user);

            await context.SaveChangesAsync();
        }
    }
}