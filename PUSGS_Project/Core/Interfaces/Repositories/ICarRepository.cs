using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetAsync(long id);

        Task<bool> AddAsync(Car car);

        Task DeleteAsync(long id);

        Task UpdateAsync(Car car);
    }
}
