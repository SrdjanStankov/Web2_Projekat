using Core.Entities;
using Core.Interfaces.Repositories;
using System;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public bool Add(User user)
        {
            var u = context.Find<User>(user.Email);
            if (u is object)
            {
                return false;
            }
            //TODO: make async
            context.Add(user);
            context.SaveChanges();
            return true;
        }

        public void DeleteUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            return context.Find<User>(email);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}