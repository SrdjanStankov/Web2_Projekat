using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Persistance.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext context;

        public CarRepository(ApplicationDbContext context)
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
            var car = await context.Car.FindAsync(id);
            context.Car.Remove(car);
            await context.SaveChangesAsync();
        }

        public async Task<Car> GetAsync(long id)
        {
            return await context.FindAsync<Car>(id);
        }

        public async Task UpdateAsync(Car car)
        {
            context.Update(car);
            await context.SaveChangesAsync();
        }
    }
}
