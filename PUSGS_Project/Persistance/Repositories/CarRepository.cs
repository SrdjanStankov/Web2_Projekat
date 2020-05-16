using System;
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

        public void Add(Car car)
        {
            context.Add(car);
            context.SaveChanges();
        }

        public void Delete(long id) => throw new NotImplementedException();

        public Car Get(long id) => context.Find<Car>(id);

        public void Update(Car car) => throw new NotImplementedException();
    }
}
