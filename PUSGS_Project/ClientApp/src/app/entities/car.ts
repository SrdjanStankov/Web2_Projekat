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
  averageRating: number;
  costForRange: number;
  rentACarId: number;


  constructor(name: string, passengerNumber: number, type: string, brand: string, model:string, buildDate: number, costPerDay: number) {
    this.name = name;
    this.passengerNumber = passengerNumber;
    this.type = type;
    this.brand = brand;
    this.model = model;
    this.buildDate = buildDate;
    this.costPerDay = costPerDay;
  }

}
