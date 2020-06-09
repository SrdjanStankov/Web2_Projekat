export class UpdateFlightRequest {
  departureTime: Date = new Date();
  arrivalTime: Date = new Date();
  travelLength: number;
  ticketPrice: number;
  numberOfChangeovers: number;

  constructor(
    {
      departureTime = new Date(),
      arrivalTime = new Date(),
      travelLength = 0,
      ticketPrice = 0,
      numberOfChangeovers = 0
    } = {}) {
    this.departureTime = departureTime;
    this.arrivalTime = arrivalTime;
    this.travelLength = travelLength;
    this.ticketPrice = ticketPrice;
    this.numberOfChangeovers = numberOfChangeovers;
  }
}
