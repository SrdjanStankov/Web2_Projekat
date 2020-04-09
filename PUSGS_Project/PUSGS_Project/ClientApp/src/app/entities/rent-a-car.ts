import { Car } from "./car";

export class RentACar {

  name: string;
  address: string;
  description: string;
  cars: Car[];
  branches: string[];

  constructor(name: string, address: string, description: string, branches: string[], cars: Car[]) {
    this.name = name;
    this.address = address;
    this.description = description;
    this.branches = branches;
    this.cars = cars;
  }
}
