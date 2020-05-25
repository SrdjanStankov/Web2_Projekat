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
                .Include(c => c.Flights)
                .Include(c => c.Ratings)
                .ToListAsync();
        }

        public Task<AviationCompany> GetByIdAsync(long id)
        {
            return context.AviationCompany
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
            entity.Name = company.Name;
            entity.Description = company.Description;

            if (company.Address != null)
            {
                entity.Address.CityName = company.Address.CityName;
                entity.Address.X = company.Address.X;
                entity.Address.Y = company.Address.Y;
            }

            await context.SaveChangesAsync();
        }
    }
}