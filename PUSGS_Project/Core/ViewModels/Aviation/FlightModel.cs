using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ViewModels.Aviation
{
    public class FlightModel
    {
        public long Id { get; set; }

        public long AviationCompanyId { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public double TravelLength { get; set; }
        public double TicketPrice { get; set; }
        public int NumberOfChangeovers { get; set; }

        public ICollection<FlightTicketModel> Tickets { get; set; }
        public ICollection<FlightSeatModel> Seats { get; set; }
        public ICollection<RatingModel> Ratings { get; set; }

        public FlightModel()
        {
        }

        public FlightModel(Flight flight)
        {
            Id = flight.Id;
            AviationCompanyId = flight.AviationCompanyId;
            DepartureTime = flight.DepartureTime;
            ArrivalTime = flight.ArrivalTime;
            TravelLength = flight.TravelLength;
            TicketPrice = flight.TicketPrice;
            NumberOfChangeovers = flight.NumberOfChangeovers;

            Tickets = flight.Tickets.Select(t => new FlightTicketModel(t)).ToList();
            Seats = flight.Seats.Select(s => AviationMapper.MapSeat(s, flight.Tickets)).ToList();
            Ratings = flight.Ratings.Select(r => new RatingModel(r)).ToList();
        }
    }
}