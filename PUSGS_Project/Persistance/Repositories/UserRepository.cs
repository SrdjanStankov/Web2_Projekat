using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await context.User.ToListAsync();
            var userFriends = await context.UserFriends
                .Include(u => u.User)
                .Include(u => u.Friend)
                .ToListAsync();

            foreach (var user in users)
            {
                user.Friends = userFriends
                    .Where(x => x.UserEmail == user.Email || x.FriendEmail == user.Email)
                    .Select(u => u.UserEmail == user.Email ? u.Friend : u.User)
                    .ToList();
            }

            return users;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            var friends = await context.UserFriends
                .Include(x => x.User)
                .Include(x => x.Friend)
                .Where(x => x.UserEmail == user.Email || x.FriendEmail == user.Email)
                .ToListAsync();

            user.Friends = friends.Select(u => u.UserEmail == user.Email ? u.Friend : u.User).ToList();

            return user;
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

            var userFriends = await context.UserFriends.Where(x => x.UserEmail == user.Email || x.FriendEmail == user.Email).ToListAsync();
            context.UserFriends.RemoveRange(userFriends);
            await context.SaveChangesAsync();

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
            if (!context.UserFriends.Any(GetAreFriendsExpression(userId, friendId)))
            {
                await context.UserFriends.AddAsync(new UserFriends(userId, friendId));
                await context.SaveChangesAsync();
            }
        }

        public async Task UnfriendAsync(string userId, string friendId)
        {
            var query = await context.UserFriends.Where(GetAreFriendsExpression(userId, friendId)).ToListAsync();
            context.UserFriends.RemoveRange(query);

            await context.SaveChangesAsync();
        }

        private static Expression<Func<UserFriends, bool>> GetAreFriendsExpression(string userId, string friendId)
        {
            return x => (x.UserEmail == userId || x.FriendEmail == userId) && (x.UserEmail == friendId || x.FriendEmail == friendId);
        }
    }
}