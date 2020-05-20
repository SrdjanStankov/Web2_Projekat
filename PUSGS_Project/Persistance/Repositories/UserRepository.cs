using Core.Entities;
using Core.Interfaces.Repositories;
using System;
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

        public async Task<bool> AddAsync(User user)
        {
            var u = await context.FindAsync<User>(user.Email);
            if (u is object)
            {
                return false;
            }
            await context.AddAsync(user);
            await context.SaveChangesAsync();
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