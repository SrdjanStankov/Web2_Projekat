export class Car {

  private name: string;
  private passengerNumber: number;
  private ratings: number[];
  private reservedFrom: Date = new Date();
  private reservedTo: Date = new Date();

  get PassengerNumber() {
    return this.passengerNumber;
  }

  set PassengerNumber(value: number) {
    this.passengerNumber = value;
  }

  get Name() {
    return this.name;
  }

  set Name(value: string) {
    this.name = value;
  }

  constructor(name: string) {
    this.name = name;
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
