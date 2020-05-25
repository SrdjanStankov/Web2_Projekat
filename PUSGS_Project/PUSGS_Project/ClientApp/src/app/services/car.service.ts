import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Car } from '../entities/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  http: HttpClient;
  carControllerUri: string;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.http = http;
    this.carControllerUri = baseUrl + "api/car/";
  }

  addCar(car: Car): Promise<Car> {
    return this.http.post<Car>(this.carControllerUri, car).toPromise();
  }

  getCar(id: number): Promise<Car> {
    return this.http.get<Car>(this.carControllerUri + id).toPromise();
  }

  updateCar(car: Car) {
    return this.http.put<Car>(this.carControllerUri + car.id, car).toPromise();
  }

  removeCar(index: number) {
    return this.http.delete<Car>(this.carControllerUri + index).toPromise();
  }
}