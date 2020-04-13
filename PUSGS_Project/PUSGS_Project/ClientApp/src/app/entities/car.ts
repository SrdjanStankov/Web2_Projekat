export class Car {

  private name: string;
  private passengerNumber: number;
  private ratings: number[];
  private reservedFrom: Date = new Date();
  private reservedTo: Date = new Date();
  private type: string;

  get PassengerNumber() { return this.passengerNumber; }
  get Name() { return this.name; }
  get ReservedFrom() { return this.reservedFrom; }
  get ReservedTo() { return this.reservedTo; }
  get Type() { return this.type; }

  set Type(value: string) { this.type = value; }
  set ReservedFrom(value: Date) { this.reservedFrom = value; }
  set ReservedTo(value: Date) { this.reservedTo = value; }
  set PassengerNumber(value: number) { this.passengerNumber = value; }
  set Name(value: string) { this.name = value; }

  constructor(name: string, passengerNumber: number, type: string) {
    this.name = name;
    this.passengerNumber = passengerNumber;
    this.type = type;
  }

  public addRating(rating: number) {
    this.ratings.push(rating);
  }

  public averageRating() {
    var sum = 0;
    this.ratings.forEach((val) => {
      sum += val;
    });

    return (sum / this.ratings.length).toFixed(2);
  }

  public reserveCar(reservationStartDate: Date, reservationEndDate: Date): boolean {
    if (!this.isReserved) {
      this.reservedFrom = reservationStartDate;
      this.reservedTo = reservationEndDate;
      return true;
    }
    return false;
  }

  public isReserved(): boolean {
    if (this.reservedFrom.getTime() <= Date.now() && Date.now() <= this.reservedTo.getTime()) {
      return true;
    }
    return false;
  }

  public toString(): string {
    return this.name;
  }
}
