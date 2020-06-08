using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Core.ViewModels.Aviation
{
    /// <summary>
    /// Helper class for mapping entitites
    /// </summary>
    internal static class AviationMapper
    {
        public static FlightSeatModel MapSeat(FlightSeat seat, ICollection<FlightTicket> tickets)
        {
            return new FlightSeatModel(seat)
            {
                ReservedById = tickets.FirstOrDefault(t => t.FlightSeatId == seat.Id)?.Id
            };
        }
    }
}