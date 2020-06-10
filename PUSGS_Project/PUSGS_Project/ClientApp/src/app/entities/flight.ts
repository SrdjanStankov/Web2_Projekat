import { msToTimeString } from "../util/time";
import { FlightTicket } from "./flight-ticket";
import { Rating } from "./rating";
import { FlightSeat } from "./flight-seat";
import { Location } from "./location";

export class Flight {
  id: number;
  aviationCompanyId: number;
  aviationCompanyName: string;
  departureTime: Date = new Date();
  arrivalTime: Date = new Date();
  travelLength: number;
  ticketPrice: number;
  numberOfChangeovers: number;
  from: Location;
  to: Location;
  tickets: FlightTicket[];
  ratings: Rating[];
  seats: FlightSeat[];
}
