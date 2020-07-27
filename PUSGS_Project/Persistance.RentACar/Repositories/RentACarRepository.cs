using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.RentACar.Repositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly RentACarDbContext context;

        public RentACarRepository(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(Core.Entities.RentACar rentACar)
        {
            var r = await context.FindAsync<Core.Entities.RentACar>(rentACar.Id);
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
            var rentACar = await context.FindAsync<Core.Entities.RentACar>(rentACarId);

            rentACar.Cars.Add(car);
            await context.SaveChangesAsync();
        }

        public async Task AddBranchToAgencyAsync(long branchId, long rentACarId)
        {
            var branch = await context.Branches.FindAsync(branchId);
            var rentACar = await context.RentACars.FindAsync(rentACarId);

            rentACar.Branches.Add(branch);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var agency = await context.RentACars.FindAsync(id);
            context.RentACars.Remove(agency);
            await context.SaveChangesAsync();
        }

        public async Task<Core.Entities.RentACar> GetAsync(long id) => await context.RentACars.Include(r => r.Cars).ThenInclude(item => item.Ratings).Include(r => r.Branches).Include(r => r.Ratings).FirstOrDefaultAsync(r => r.Id == id);

        public async Task<IEnumerable<Core.Entities.RentACar>> GetAllAsync()
        {
            var rentACars = context.RentACars;
            var includableQueryables = rentACars.Include(r => r.Cars);
            var includableQueryables1 = includableQueryables.ThenInclude(item => item.Ratings);
            var includableQueryables2 = includableQueryables1.Include(r => r.Branches);
            var includableQueryables3 = includableQueryables2.Include(r => r.Ratings);
            return await includableQueryables3.ToListAsync();
        }

        public async Task UpdateAsync(Core.Entities.RentACar rentACar)
        {
            context.Update(rentACar);
            await context.SaveChangesAsync();
        }
    }
}
