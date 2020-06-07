using System;

namespace Core.Entities
{
    public class FlightTicket
    {
        public long Id { get; set; }

        public string TicketOwnerEmail { get; set; }
        public User TicketOwner { get; set; }

        public long FlightId { get; set; }
        public Flight Flight { get; set; }

        public long? FlightSeatId { get; set; }
        public FlightSeat FlightSeat { get; set; }

        public double Discount { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public bool Accepted { get; set; }
    }
}