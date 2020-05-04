using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);

        void Add(User user);

        void DeleteUserByEmail(string email);

        void Update(User user);
    }
}