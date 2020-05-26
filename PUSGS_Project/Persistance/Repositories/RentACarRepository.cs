using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly ApplicationDbContext context;

        public RentACarRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(RentACar rentACar)
        {
            var r = await context.FindAsync<RentACar>(rentACar.Id);
            if (r is object)
            {
                return false;
            }
            await context.AddAsync(rentACar);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task AddCarToAgencyAsync(long carId, long rentACarId)
        {
            var car = await context.FindAsync<Car>(carId);
            var rentACar = await context.FindAsync<RentACar>(rentACarId);

            rentACar.Cars.Add(car);
            await context.SaveChangesAsync();
        }

        public void Delete(long id) => throw new NotImplementedException();

        public RentACar Get(long id) => context.RentACar.Include(r => r.Cars).Include(r => r.Branches).FirstOrDefault(r => r.Id == id);

        public IEnumerable<RentACar> GetAll() => context.RentACar.Include(r => r.Cars).Include(r => r.Branches).AsEnumerable();

        public void Update(RentACar rentACar) => throw new NotImplementedException();
    }
}
