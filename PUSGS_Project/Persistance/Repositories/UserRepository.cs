using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public void MakeFriends(string userId, string friendId)
        {
            var user = GetUserByEmail(userId);
            var friend = GetUserByEmail(friendId);

            if (!user.Friends.Any(f => f.Email == friend.Email))
            {
                user.Friends.Add(friend);
                friend.Friends.Add(user);
                context.SaveChanges();
            }
        }

        public void Add(User user)
        {
            context.Add(user);
            context.SaveChanges();
        }

        public void DeleteUserByEmail(string email)
        {
            var user = GetUserByEmail(email);
            context.User.Remove(user);
            context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return context.User.Include(u => u.Friends).FirstOrDefault(u => u.Email == email);
        }

        public void Update(User user)
        {
            var dbUser = GetUserByEmail(user.Email);

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

            context.SaveChanges();
        }
    }
}