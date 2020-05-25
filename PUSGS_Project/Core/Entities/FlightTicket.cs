﻿namespace Core.Entities
{
    public class FlightTicket
    {
        public long Id { get; set; }
        public User TicketOwner { get; set; }

        public long FlightId { get; set; }
        public Flight Flight { get; set; }
        public double Discount { get; set; }
        public int AirplaneSeat { get; set; }
    }
}