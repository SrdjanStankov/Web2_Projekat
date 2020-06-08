using Core.Entities;
using Core.ViewModels.Aviation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IFlightTicketRepository
    {
        public Task<FlightTicket> GetByIdAsync(long ticketId);

        public Task<long> AddAsync(FlightTicket flightTicket);

        public Task AddRangeAsync(IEnumerable<FlightTicket> flightTickets);

        public Task RemoveAsync(long flightTicketId);

        Task AcceptAsync(FlightTicket flightTicket);

        Task<List<FlightTicket>> GetDetailedTicketsByOwnerEmailAsync(string userEmail);
    }
}