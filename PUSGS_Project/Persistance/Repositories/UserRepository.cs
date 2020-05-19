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

        public void Add(User user)
        {
            // TODO: check if user is already registered

            //TODO: make async
            context.Add(user);
            context.SaveChanges();
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