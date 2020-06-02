using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> AddAsync(Flight company)
        {
            var dbFlight = await _context.Flight.AddAsync(company);
            await _context.SaveChangesAsync();
            return dbFlight.Entity.Id;
        }

        public Task<List<Flight>> GetAllAsync()
        {
            return _context.Flight
                .Include(f => f.From)
                .Include(f => f.To)
                .Include(f => f.Ratings).ToListAsync();
        }

        public Task<Flight> GetByIdAsync(long id)
        {
            return _context.Flight
                .Include(f => f.From)
                .Include(f => f.To)
                .Include(f => f.Ratings)
                .Include(f => f.Seats)
                .Include(f => f.Tickets)
                .Include(f => f.AviationCompany)
                .SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task RemoveAsync(long id)
        {
            var flight = await GetByIdAsync(id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Flight company)
        {
            throw new NotImplementedException();
        }
    }
}