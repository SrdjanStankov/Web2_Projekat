import { msToTimeString } from "../util/time";

export class Flight {
  private departureTime: Date = new Date();
  private arrivalTime: Date = new Date();
  private travelLength: number;
  private ticketPrice: number;
  private numberOfChangeovers: number;

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
