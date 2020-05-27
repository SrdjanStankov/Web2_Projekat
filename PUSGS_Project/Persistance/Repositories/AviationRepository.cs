using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AviationRepository : IAviationRepository
    {
        private readonly ApplicationDbContext context;

        public AviationRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        /// <summary>
        /// Adds company and returns Id of newly created entity
        /// </summary>
        /// <returns>Id of created Entity</returns>
        public async Task<long> AddAsync(AviationCompany company)
        {
            var dbCompany = await context.AviationCompany.AddAsync(company);
            await context.SaveChangesAsync();
            return dbCompany.Entity.Id;
        }

        public Task<List<AviationCompany>> GetAllAsync()
        {
            return context.AviationCompany
                .Include(c => c.Address)
                .Include(c => c.Flights)
                .Include(c => c.Ratings)
                .ToListAsync();
        }

        public Task<AviationCompany> GetByIdAsync(long id)
        {
            return context.AviationCompany
                .Include(c => c.Address)
                .Include(c => c.Flights).ThenInclude(f => f.From)
                .Include(c => c.Flights).ThenInclude(f => f.To)
                .Include(c => c.Flights).ThenInclude(f => f.Ratings)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task RemoveAsync(long id)
        {
            var company = await context.AviationCompany.FindAsync(id);
            context.AviationCompany.Remove(company);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AviationCompany company)
        {
            var entity = await GetByIdAsync(company.Id);

            if (!string.IsNullOrWhiteSpace(company.Name))
                entity.Name = company.Name;

            if (!string.IsNullOrWhiteSpace(company.Description))
                entity.Description = company.Description;

            AddOrUpdateAddress(entity, company.Address);

            await context.SaveChangesAsync();
        }

        private static void AddOrUpdateAddress(AviationCompany entity, Location address)
        {
            if (address == null)
                return;

            if (entity.Address == null)
            {
                entity.Address = address;
                return;
            }

            if (!string.IsNullOrWhiteSpace(address.CityName))
                entity.Address.CityName = address.CityName;

            entity.Address.X = address.X;
            entity.Address.Y = address.Y;
        }
    }
}