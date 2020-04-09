import { Injectable } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { Car } from '../entities/car';

@Injectable({
  providedIn: 'root'
})
export class RentACarService {

  agencies: RentACar[] = [];

  constructor() {
    const agency = new RentACar(
      "Test name",
      "Test address",
      "Test description",
      [
        "Test branch 1",
        "Test branch 2",
      ],
      [
        new Car("Test car name 1"),
        new Car("Test car name 2"),
      ]
    );

    this.agencies.push(agency);
  }

  getAgency(id: number): RentACar {
    return this.agencies[id];
  }
}
