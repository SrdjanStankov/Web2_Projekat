using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
	public interface ICarRepository
    {
        Task<Car> GetAsync(long id);

        Task<IEnumerable<Car>> GetCarsOfAgencyAsync(long rentACarId);

        Task<bool> AddAsync(Car car);

        Task DeleteAsync(long id);

        Task UpdateAsync(Car car);

        Task<double> GetAverageRatingAsync(long id);
    }
}
