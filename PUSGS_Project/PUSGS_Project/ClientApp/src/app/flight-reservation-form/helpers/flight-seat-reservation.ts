export class FlightSeatReservation {
  ticketOwnerEmail: string;
  flightId: number;
  flightSeatId: number;
  flightSeatNumber: number;

  constructor({ ticketOwnerEmail = "", flightId = -1, flightSeatId = -1, flightSeatNumber = -1 } = {}) {
    this.ticketOwnerEmail = ticketOwnerEmail;
    this.flightId = flightId;
    this.flightSeatId = flightSeatId;
    this.flightSeatNumber = flightSeatNumber;
  }
}
