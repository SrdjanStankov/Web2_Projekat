using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Flight
    {
        public long Id { get; set; }
        public AviationCompany AviationCompany { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public double TravelLength { get; set; }
        public double TicketPrice { get; set; }
        public int NumberOfChangeovers { get; set; }
        public ICollection<FlightTicket> Tickets { get; set; }

        [NotMapped]
        public ICollection<bool> SeatAvailability { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public Flight()
        {
            Tickets = new HashSet<FlightTicket>();
            SeatAvailability = new List<bool>();
            Ratings = new HashSet<Rating>();
        }
    }
}