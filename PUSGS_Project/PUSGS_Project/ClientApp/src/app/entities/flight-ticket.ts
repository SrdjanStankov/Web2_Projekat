import { Flight } from "./flight";
import { FlightSeat } from "./flight-seat";

export class FlightTicket {
  ticketOwnerEmail: string;
  flightId: number;
  flightSeatId: number;
  discount: number;
  canCancel: boolean;
  accepted: boolean;

  constructor({ ticketOwnerEmail = "", flightId = -1, flightSeatId = -1, discount = 0, canCancel = true } = {}) {
    this.ticketOwnerEmail = ticketOwnerEmail;
    this.flightId = flightId;
    this.flightSeatId = flightSeatId;
    this.discount = discount;
    this.canCancel = canCancel;
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
  canCancel: boolean;
}
