import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Flight } from '../entities/flight';
import { AddFlightRequest } from '../entities/requests/add-flight-request';

@Injectable({
  providedIn: 'root'
})
export class FlightService {
  http: HttpClient;
  flightControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.flightControllerUri = baseUrl + 'api/flight/';
  }
  getAll(): Promise<Flight[]> {
    return this.http.get<Flight[]>(this.flightControllerUri).toPromise();
  }
  get(id: number): Promise<Flight> {
    return this.http.get<Flight>(this.flightControllerUri + id).toPromise();
  }
  add(request: AddFlightRequest) {
    return this.http.post(this.flightControllerUri, request).toPromise();
  }
  delete(id: number) {
    return this.http.delete(this.flightControllerUri + id).toPromise();
  }
}
