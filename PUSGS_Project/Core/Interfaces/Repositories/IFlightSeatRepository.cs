using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IFlightSeatRepository
    {
        public Task<long> AddAsync(FlightSeat flightSeat);

        public Task AddRangeAsync(IEnumerable<FlightSeat> flightSeats);
    }
}