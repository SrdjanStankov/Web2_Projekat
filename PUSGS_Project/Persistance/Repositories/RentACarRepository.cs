using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;

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

        public void Delete(long id) => throw new NotImplementedException();

        public RentACar Get(long id) => context.Find<RentACar>(id);

        public IEnumerable<RentACar> GetAll() => context.Set<RentACar>().AsEnumerable();

        public void Update(RentACar rentACar) => throw new NotImplementedException();
    }
}
