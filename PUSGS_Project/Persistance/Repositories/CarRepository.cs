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

        public void Delete(long id) => throw new NotImplementedException();

        public Car Get(long id) => context.Find<Car>(id);

        public void Update(Car car) => throw new NotImplementedException();
    }
}
