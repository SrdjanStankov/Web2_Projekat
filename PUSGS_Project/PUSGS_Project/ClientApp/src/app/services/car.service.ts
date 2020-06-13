import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
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

  getCars(rentACarId: number, passengerNumber: string, type: string, returnDate: string, takeDate: string, maxCost: string, all: string = "false"): Promise<Car[]> {
    let params = new HttpParams().set("passengerNumber", passengerNumber).set("type", type).set("returnDate", returnDate).set("takeDate", takeDate).set("maxCost", maxCost).set("all", all);
    return this.http.get<Car[]>(this.carControllerUri + "RentACar/" + rentACarId, { params: params }).toPromise();
  }

  updateCar(car: Car) {
    return this.http.put<Car>(this.carControllerUri + car.id, car).toPromise();
  }

  removeCar(index: number) {
    return this.http.delete<Car>(this.carControllerUri + index).toPromise();
  }

}
