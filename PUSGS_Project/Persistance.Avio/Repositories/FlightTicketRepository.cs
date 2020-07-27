using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Avio.Repositories
{
    public class FlightTicketRepository : IFlightTicketRepository
    {
        private readonly AvioDbContext _context;

        public FlightTicketRepository(AvioDbContext context)
        {
            _context = context;
        }

        public async Task<long> AddAsync(FlightTicket flightTicket)
        {
            if (string.IsNullOrWhiteSpace(flightTicket.TicketOwnerEmail))
            {
                flightTicket.TicketOwnerEmail = null;
            }

            var entry = await _context.FlightTickets.AddAsync(flightTicket);
            await _context.SaveChangesAsync();
            return entry.Entity.Id;
        }

        public async Task AddRangeAsync(IEnumerable<FlightTicket> flightTickets)
        {
            await _context.FlightTickets.AddRangeAsync(flightTickets);
            await _context.SaveChangesAsync();
        }

        public Task<List<FlightTicket>> GetAllByAviationIdAsync(long aviationId) => _context.FlightTickets
                .Include(t => t.FlightSeat)
                .Include(t => t.Flight)
                .ThenInclude(f => f.AviationCompany)
                .Include(t => t.Flight)
                .ThenInclude(f => f.From)
                .Include(t => t.Flight)
                .ThenInclude(f => f.To)
                .Where(t => t.Flight.AviationCompanyId == aviationId)
                .ToListAsync();

        public Task<FlightTicket> GetByIdAsync(long ticketId) => _context.FlightTickets.SingleOrDefaultAsync(t => t.Id == ticketId);

        public async Task RemoveAsync(long flightTicketId)
        {
            var entity = await GetByIdAsync(flightTicketId);
            _context.FlightTickets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptAsync(long flightTicketId)
        {
            var entity = await GetByIdAsync(flightTicketId);
            entity.Accepted = true;
            await _context.SaveChangesAsync();
        }

        public Task<List<FlightTicket>> GetDetailedTicketsByOwnerEmailAsync(string userEmail) => _context.FlightTickets
                .Include(t => t.Flight).ThenInclude(f => f.From)
                .Include(t => t.Flight).ThenInclude(f => f.To)
                .Include(t => t.FlightSeat)
                .Where(t => t.TicketOwnerEmail == userEmail)
                .ToListAsync();

        public async Task UpdateAsync(FlightTicket flightTicket)
        {
            var ticket = await GetByIdAsync(flightTicket.Id);
            ticket.TicketOwnerEmail = flightTicket.TicketOwnerEmail;
            ticket.Discount = flightTicket.Discount;
            ticket.Rating = flightTicket.Rating;
            await _context.SaveChangesAsync();
        }
    }
}
