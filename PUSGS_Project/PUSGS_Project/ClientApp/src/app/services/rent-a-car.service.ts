import { Injectable } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { Car } from '../entities/car';

@Injectable({
  providedIn: 'root'
})
export class RentACarService {

  agencies: RentACar[] = [];

  constructor() {
    let agency = new RentACar(
      "Test name",
      "Test address",
      "Test description",
      [
        "Test branch 1",
        "Test branch 2",
        "Test branch 2",
        "Test branch 2",
      ],
      [
        new Car("Test car name 1", 4, "Suv", "Brand 1", "Model 1", 2009, 20),
        new Car("Test car name 1", 4, "Suv", "Brand 1", "Model 1", 2019, 14),
        new Car("Test car name 1", 4, "Suv", "Brand 1", "Model 1", 2018, 28),
        new Car("Test car name 2", 2, "Sport", "Brand 1", "Model 1", 2007, 10),
        new Car("Test car name 2", 2, "Suv", "Brand 1", "Model 1", 2000, 28),
        new Car("Test car name 2", 8, "Minivan", "Brand 1", "Model 1", 2001, 37),
        new Car("Test car name 2", 6, "Coupe", "Brand 1", "Model 1", 2004, 11),
        new Car("Test car name 2", 2, "Sport", "Brand 1", "Model 1", 2020, 5),
      ]
    );
    agency.Cars[0].addRating(3);
    agency.Cars[0].addRating(4);
    agency.Cars[0].addRating(6);
    agency.addRating(4);
    agency.addRating(3);
    agency.addRating(6);

    let agency2 = new RentACar(
      "Test name 2",
      "Test address 2",
      "Test description 2",
      [
        "Test branch 1",
        "Test branch 2",
      ],
      [
        new Car("Test car name 1", 2, "Suv", "Brand 1", "Model 1", 2009, 20),
        new Car("Test car name 2", 8, "Minivan", "Brand 1", "Model 1", 2009, 20),
      ]
    );
    agency2.addRating(4);
    agency2.addRating(5);
    agency2.addRating(7);


    this.agencies.push(agency);
    this.agencies.push(agency);
    this.agencies.push(agency);
    this.agencies.push(agency2);
    this.agencies.push(agency2);
    this.agencies.push(agency2);
  }

  getAgencies(): RentACar[] {
    return this.agencies;
  }

  getAgency(id: number): RentACar {
    return this.agencies[id];
  }
}
