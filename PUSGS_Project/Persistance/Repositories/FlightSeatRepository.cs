using Core.Entities;
using Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class FlightSeatRepository : IFlightSeatRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightSeatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> AddAsync(FlightSeat flightSeat)
        {
            var entry = await _context.AddAsync(flightSeat);
            await _context.SaveChangesAsync();
            return entry.Entity.Id;
        }

        public async Task AddRangeAsync(IEnumerable<FlightSeat> flightSeats)
        {
            await _context.AddRangeAsync(flightSeats);
            await _context.SaveChangesAsync();
        }
    }
}