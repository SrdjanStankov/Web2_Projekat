export class Car {

  id: number;
  name: string;
  passengerNumber: number;
  ratings: number[] = [];
  reservedFrom: Date;
  reservedTo: Date;
  type: string;
  brand: string;
  model: string;
  buildDate: number;
  costPerDay: number;

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
