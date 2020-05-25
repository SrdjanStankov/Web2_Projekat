namespace Core.Entities
{
    public class FlightSeat
    {
        public long Id { get; set; }

        public long FlightId { get; set; }
        public Flight Flight { get; set; }

        public long? ReservedById { get; set; }
        public FlightTicket ReservedBy { get; set; }
    }
}