using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.Aviation.Requests;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Avio.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AvioDbContext _context;

        public FlightRepository(AvioDbContext context)
        {
            _context = context;
        }

        public async Task<long> AddAsync(Flight company)
        {
            var dbFlight = await _context.Flights.AddAsync(company);
            await _context.SaveChangesAsync();
            return dbFlight.Entity.Id;
        }

        public Task<List<Flight>> GetAllAsync() => _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .Include(f => f.AviationCompany)
                .Include(f => f.Ratings).ToListAsync();

        public Task<Flight> GetByIdAsync(long id) => _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .Include(f => f.Ratings)
                .Include(f => f.Seats)
                .Include(f => f.Tickets)
                .Include(f => f.AviationCompany)
                .SingleOrDefaultAsync(f => f.Id == id);

        public async Task RemoveAsync(long id)
        {
            var flight = await GetByIdAsync(id);
            _context.FlightTickets.RemoveRange(flight.Tickets);
            _context.FlightSeats.RemoveRange(flight.Seats);
            _context.Locations.Remove(flight.From);
            _context.Locations.Remove(flight.To);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(long id, UpdateFlightRequestModel model)
        {
            var flight = await _context.Flights.SingleOrDefaultAsync(f => f.Id == id);

            if (model.ArrivalTime != null)
            {
                flight.ArrivalTime = model.ArrivalTime;
            }

            if (model.DepartureTime != null)
            {
                flight.DepartureTime = model.DepartureTime;
            }

            if (model.TicketPrice != null)
            {
                flight.TicketPrice = model.TicketPrice.Value;
            }

            if (model.NumberOfChangeovers != null)
            {
                flight.NumberOfChangeovers = model.NumberOfChangeovers.Value;
            }

            if (model.TravelLength != null)
            {
                flight.TravelLength = model.TravelLength.Value;
            }

            await _context.SaveChangesAsync();
        }
    }
}
