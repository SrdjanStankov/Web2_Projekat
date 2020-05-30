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

        public async Task AddBranchToAgencyAsync(long branchId, long rentACarId)
        {
            var branch = await context.Branches.FindAsync(branchId);
            var rentACar = await context.RentACar.FindAsync(rentACarId);

            rentACar.Branches.Add(branch);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var agency = await context.RentACar.FindAsync(id);
            context.RentACar.Remove(agency);
            await context.SaveChangesAsync();
        }

        public async Task<RentACar> GetAsync(long id) => await context.RentACar.Include(r => r.Cars).Include(r => r.Branches).Include(r => r.Ratings).FirstOrDefaultAsync(r => r.Id == id);

        public async Task<IEnumerable<RentACar>> GetAllAsync() => await context.RentACar.Include(r => r.Cars).Include(r => r.Branches).Include(r => r.Ratings).ToListAsync();

        public async Task UpdateAsync(RentACar rentACar)
        {
            context.Update(rentACar);
            await context.SaveChangesAsync();
        }

        public async Task<double> GetAverageRatingAsync(long id)
        {
            var agencies = await GetAsync(id);
            return agencies.Ratings.DefaultIfEmpty(new Rating()).Average(rating => rating.Value);
        }
    }
}
