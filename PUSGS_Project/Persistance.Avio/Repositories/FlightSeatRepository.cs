using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Persistance.Avio.Repositories
{
    public class FlightSeatRepository : IFlightSeatRepository
    {
        private readonly AvioDbContext _context;

        public FlightSeatRepository(AvioDbContext context)
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
