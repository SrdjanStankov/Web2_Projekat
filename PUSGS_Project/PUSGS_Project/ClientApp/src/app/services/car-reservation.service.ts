import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CarReservation } from '../entities/car-reservation';

@Injectable({
  providedIn: 'root'
})
export class CarReservationService {
  http: HttpClient;
  carReservationControllerUri: string;

  constructor(http: HttpClient, @Inject("BASE_RENTACAR_URL") baseUrl: string) {
    this.http = http;
    this.carReservationControllerUri = baseUrl + "api/carReservation/";
  }

  reserveCar(reservation: CarReservation) {
    return this.http.post(this.carReservationControllerUri, reservation).toPromise();
  }

  getReservations(userEmail: string) {
    return this.http.get<CarReservation[]>(this.carReservationControllerUri + userEmail).toPromise();
  }

  getQuickReservations(rentACarAgencyId: number) {
    return this.http.get<CarReservation[]>(this.carReservationControllerUri + "QuickReservation/" + rentACarAgencyId).toPromise();
  }

  updateReservationWithUser(ticket: CarReservation) {
    return this.http.put<CarReservation>(this.carReservationControllerUri, ticket).toPromise();
  }

}
