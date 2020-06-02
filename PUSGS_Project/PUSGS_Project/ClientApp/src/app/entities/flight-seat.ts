export class FlightSeat {
  id: number;
  flightId: number;

  // Id of flight ticket that reserved this seat (nullable)
  reservedById: number;
}
