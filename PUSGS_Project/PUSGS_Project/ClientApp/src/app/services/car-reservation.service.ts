import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CarReservation } from '../entities/car-reservation';

@Injectable({
  providedIn: 'root'
})
export class CarReservationService {
  http: HttpClient;
  carControllerUri: string;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.http = http;
    this.carControllerUri = baseUrl + "api/carReservation/";
  }

  reserveCar(reservation: CarReservation) {
    return this.http.post(this.carControllerUri, reservation).toPromise();
  }

}
