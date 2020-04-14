export class Car {

  private name: string;
  private passengerNumber: number;
  private ratings: number[] = [];
  private reservedFrom: Date;
  private reservedTo: Date;
  private type: string;
  private brand: string;
  private model: string;
  private buildDate: number;
  private costPerDay: number;

  get PassengerNumber() { return this.passengerNumber; }
  get Name() { return this.name; }
  get ReservedFrom() { return this.reservedFrom; }
  get ReservedTo() { return this.reservedTo; }
  get Type() { return this.type; }
  get Brand() { return this.brand; }
  get Model() { return this.model; }
  get BuildDate() { return this.buildDate; }

  set Type(value: string) { this.type = value; }
  set ReservedFrom(value: Date) { this.reservedFrom = value; }
  set ReservedTo(value: Date) { this.reservedTo = value; }
  set PassengerNumber(value: number) { this.passengerNumber = value; }
  set Name(value: string) { this.name = value; }
  set Brand(value: string) { this.brand = value; }
  set Model(value: string) { this.model = value; }
  set BuildDate(value: number) { this.buildDate = value; }

  constructor(name: string, passengerNumber: number, type: string, brand: string, model:string, buildDate: number, costPerDay: number) {
    this.name = name;
    this.passengerNumber = passengerNumber;
    this.type = type;
    this.brand = brand;
    this.model = model;
    this.buildDate = buildDate;
    this.costPerDay = costPerDay;
  }

  public calculateCostForRange(from: Date, to: Date) {
    return Math.round(Math.abs((from.getTime() - to.getTime()) / (24 * 60 * 60 * 1000))) * this.costPerDay;
  }

  public addRating(rating: number) {
    this.ratings.push(rating);
  }

  public averageRating() {
    if (this.ratings.length === 0) {
      return 0;
    }
    var sum = 0;
    this.ratings.forEach((val) => {
      sum += val;
    });

    return (sum / this.ratings.length).toFixed(2);
  }

  public reserveCar(reservationStartDate: Date, reservationEndDate: Date): boolean {
    if (!this.isReserved()) {
      this.reservedFrom = reservationStartDate;
      this.reservedTo = reservationEndDate;
      return true;
    }
    return false;
  }

  public isReserved(): boolean {
    if (!this.reservedFrom || !this.reservedTo) {
      return false;
    }
    if (this.reservedFrom.getTime() <= Date.now() && Date.now() <= this.reservedTo.getTime()) {
      return true;
    }
    return false;
  }

  public toString(): string {
    return this.name;
  }
}
