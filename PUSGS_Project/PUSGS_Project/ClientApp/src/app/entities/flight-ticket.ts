import { Flight } from "./flight";
import { FlightSeat } from "./flight-seat";

export class FlightTicket {
  ticketOwnerEmail: string;
  flightId: number;
  flightSeatId: number;
  discount: number;
  canReject: boolean;
  accepted: boolean;

  constructor({ ticketOwnerEmail = "", flightId = -1, flightSeatId = -1, discount = 0, canReject = true } = {}) {
    this.ticketOwnerEmail = ticketOwnerEmail;
    this.flightId = flightId;
    this.flightSeatId = flightSeatId;
    this.discount = discount;
    this.canReject = canReject;
  }
}

export class FlightTicketDetails {
  id: number;
  ticketOwnerEmail: string;
  flight: Flight;
  flightSeat: FlightSeat;
  discount: number;
  dateCreated: Date;
  accepted: boolean;
  canReject: boolean;
}
