using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.RentACar.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentACarDbContext context;

        public CarRepository(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(Car car)
        {
            var c = await context.FindAsync<Car>(car.Id);
            if (c is object)
            {
                return false;
            }
            await context.AddAsync(car);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(long id)
        {
            var car = await context.Cars.FindAsync(id);
            context.Cars.Remove(car);
            await context.SaveChangesAsync();
        }

        public async Task<Car> GetAsync(long id) => await context.Cars.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

        public async Task<double> GetAverageRatingAsync(long id)
        {
            var car = await GetAsync(id);
            return car.Ratings.DefaultIfEmpty(new Rating()).Average(rating => rating.Value);
        }

        public async Task<IEnumerable<Car>> GetCarsOfAgencyAsync(long rentACarId) => (await context.RentACars.Include(r => r.Cars).FirstOrDefaultAsync(item => item.Id == rentACarId))?.Cars;

        public async Task UpdateAsync(Car car)
        {
            context.Cars.Update(car);
            await context.SaveChangesAsync();
        }
    }
}
