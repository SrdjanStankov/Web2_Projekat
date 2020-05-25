namespace Core.Entities
{
    public class FlightTicket
    {
        public long Id { get; set; }

        public long TicketOwnerId { get; set; }
        public User TicketOwner { get; set; }

        public long FlightId { get; set; }
        public Flight Flight { get; set; }

        public long? FlightSeatId { get; set; }
        public FlightSeat FlightSeat { get; set; }

        public double Discount { get; set; }
    }
}