import { Injectable, Inject } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RentACarService {

  http: HttpClient;
  rentACarControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //http.get<RentACar[]>(baseUrl + 'api/rentacar').subscribe(result => { this.agencies = result; }, error => console.error(error));
    this.http = http;
    this.rentACarControllerUri = baseUrl + 'api/rentacar/';
  }

  getAgencies(): Promise<RentACar[]> {
    return this.http.get<RentACar[]>(this.rentACarControllerUri).toPromise();
  }

  getAgency(id: number): Promise<RentACar> {
    return this.http.get<RentACar>(this.rentACarControllerUri + id).toPromise();
  }
}
