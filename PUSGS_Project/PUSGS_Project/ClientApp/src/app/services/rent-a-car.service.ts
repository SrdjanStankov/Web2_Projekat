import { Injectable, Inject } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RentACarService {

  agencies: RentACar[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<RentACar[]>(baseUrl + 'api/rentacar').subscribe(result => {
      this.agencies = result;
    }, error => console.error(error));
  }

  getAgencies(): RentACar[] {
    return this.agencies;
  }

  getAgency(id: number): RentACar {
    return this.agencies[id];
  }
}
