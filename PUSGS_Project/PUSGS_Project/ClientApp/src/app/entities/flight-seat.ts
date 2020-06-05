export class FlightSeat {
  id: number;
  flightId: number;

  seatNumber: number;

  // Id of flight ticket that reserved this seat (nullable)
  reservedById: number;
}
