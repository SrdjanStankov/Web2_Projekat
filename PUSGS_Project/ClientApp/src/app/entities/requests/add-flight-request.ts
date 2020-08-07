import { Location } from "../location";

export class AddFlightRequest {
  aviationCompanyId: number;
  departureTime: Date = new Date();
  arrivalTime: Date = new Date();
  travelLength: number;
  ticketPrice: number;
  numberOfChangeovers: number;
  from: Location;
  to: Location;
  numberOfSeats = 20;
  maxSeatsPerRow = 4;
}
