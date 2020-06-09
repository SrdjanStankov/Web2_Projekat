using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.Aviation.Requests;
using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateAsync(long id, UpdateFlightRequestModel model)
        {
            var flight = await _context.Flight.SingleOrDefaultAsync(f => f.Id == id);

            if (model.ArrivalTime != null)
                flight.ArrivalTime = model.ArrivalTime;

            if (model.DepartureTime != null)
                flight.DepartureTime = model.DepartureTime;

            if (model.TicketPrice != null)
                flight.TicketPrice = model.TicketPrice.Value;

            if (model.NumberOfChangeovers != null)
                flight.NumberOfChangeovers = model.NumberOfChangeovers.Value;

            if (model.TravelLength != null)
                flight.TravelLength = model.TravelLength.Value;

            await _context.SaveChangesAsync();
        }
    }
}