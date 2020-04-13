import { Flight } from "./flight";
import { User } from "./user";

export class FlightTicket {
  ticketOwner: User;
  flight: Flight;
  discount: number = 0;
  airplaneSeat: number;
}
