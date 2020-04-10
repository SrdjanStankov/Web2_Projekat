import { Car } from "./car";

export class RentACar {

  private name: string;
  private address: string;
  private description: string;
  // TODO: cenovnik
  private cars: Car[] = [];
  private branches: string[] = [];
  private ratings: number[] = [];

  get Name() { return this.name; }
  get Address() { return this.address; }
  get Description() { return this.description; }
  get Cars() { return this.cars; }
  get Branches() { return this.branches; }

  constructor(name: string, address: string, description: string, branches: string[], cars: Car[]) {
    this.name = name;
    this.address = address;
    this.description = description;
    this.branches = branches;
    this.cars = cars;
  }

  public getCar(index: number): Car {
    return this.cars[index];
  }

  public addCar(car: Car) {
    this.cars.push(car);
  }

  public removeCar(index: number): boolean {
    if (!this.cars[index].isReserved) {
      this.cars.splice(index, 1);
      return true;
    }
    return false;
  }

  public addRating(rating: number) {
    this.ratings.push(rating);
  }

  public getAverageRating() {
    var sum = 0;
    this.ratings.forEach((val) => {
      sum += val;
    });

    return (sum / this.ratings.length).toFixed(2);
  }
}
