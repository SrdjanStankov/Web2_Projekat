using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<bool> AddAsync(User user);

        void DeleteUserByEmail(string email);

        void Update(User user);
    }
}