using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICarRepository
    {
        Car Get(long id);

        Task<bool> AddAsync(Car car);

        void Delete(long id);

        void Update(Car car);
    }
}
