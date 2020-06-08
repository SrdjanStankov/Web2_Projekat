using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.Aviation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class FlightTicketRepository : IFlightTicketRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightTicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> AddAsync(FlightTicket flightTicket)
        {
            var entry = await _context.FlightTicket.AddAsync(flightTicket);
            await _context.SaveChangesAsync();
            return entry.Entity.Id;
        }

        public async Task AddRangeAsync(IEnumerable<FlightTicket> flightTickets)
        {
            await _context.FlightTicket.AddRangeAsync(flightTickets);
            await _context.SaveChangesAsync();
        }

        public Task<FlightTicket> GetByIdAsync(long ticketId)
        {
            return _context.FlightTicket.SingleOrDefaultAsync(t => t.Id == ticketId);
        }

        public async Task RemoveAsync(long flightTicketId)
        {
            var entity = await GetByIdAsync(flightTicketId);
            _context.FlightTicket.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptAsync(FlightTicket flightTicket)
        {
            var entity = await GetByIdAsync(flightTicket.Id);
            entity.Accepted = true;
            await _context.SaveChangesAsync();
        }

        public Task<List<FlightTicket>> GetDetailedTicketsByOwnerEmailAsync(string userEmail)
        {
            return _context.FlightTicket
                .Include(t => t.Flight).ThenInclude(f => f.From)
                .Include(t => t.Flight).ThenInclude(f => f.To)
                .Include(t => t.FlightSeat)
                .Where(t => t.TicketOwnerEmail == userEmail)
                .ToListAsync();
        }
    }
}