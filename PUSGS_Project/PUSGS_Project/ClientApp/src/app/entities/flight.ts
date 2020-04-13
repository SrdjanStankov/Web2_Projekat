import { msToTimeString } from "../util/time";
import { FlightTicket } from "./flight-ticket";
import { AviationCompany } from "./aviation-company";

export class Flight {
  aviationCompany: AviationCompany;
  departureTime: Date = new Date();
  arrivalTime: Date = new Date();
  travelLength: number;
  ticketPrice: number;
  numberOfChangeovers: number;
  tickets: FlightTicket[];
  seatAvailability: boolean[];
  ratings: number[];

  // TODO: dodati lokacije presedanja

  /**
   * Returns difference between departure and arrival time in milliseconds
   */
  get travelTime(): string {
    let diff = this.arrivalTime.valueOf() - this.departureTime.valueOf();
    // Math.abs is used due to possible country date/time differences
    return msToTimeString(Math.abs(diff));
  }
}
