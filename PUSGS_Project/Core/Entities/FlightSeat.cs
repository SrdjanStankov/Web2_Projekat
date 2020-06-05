namespace Core.Entities
{
    public class FlightSeat
    {
        public long Id { get; set; }

        public long FlightId { get; set; }
        public Flight Flight { get; set; }

        public long SeatNumber { get; set; }

        // Wanted to add optional FlightTicket ReservedBy but EF Core wouldn't let me because of
        // "multiple cascade paths", so I will just use application logic to check if FlightSeat is taken...
    }
}