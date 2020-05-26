import { Injectable, Inject } from "@angular/core";
import { RentACar } from "../entities/rent-a-car";
import { HttpClient } from "@angular/common/http";
import { Car } from "../entities/car";
import { Branch } from "../entities/branch";

@Injectable({
  providedIn: "root",
})
export class RentACarService {

  http: HttpClient;
  rentACarControllerUri: string;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    //http.get<RentACar[]>(baseUrl + 'api/rentacar').subscribe(result => { this.agencies = result; }, error => console.error(error));
    this.http = http;
    this.rentACarControllerUri = baseUrl + "api/rentacar/";
  }

  getAgencies(): Promise<RentACar[]> {
    return this.http.get<RentACar[]>(this.rentACarControllerUri).toPromise();
  }

  getAgency(id: number): Promise<RentACar> {
    return this.http.get<RentACar>(this.rentACarControllerUri + id).toPromise();
  }

  addAgency(agency: RentACar) {
    return this.http.post<RentACar>(this.rentACarControllerUri, agency).toPromise();
  }

  addCarToAgency(carId: number, id: number) {
    return this.http.post<Car>(this.rentACarControllerUri + "AddCar", { carId: carId, rentACarId: id }).toPromise();
  }

  addBranchToAgency(branchId: number, id: number) {
    return this.http.post<Branch>(this.rentACarControllerUri + "AddBranch", { branchId: branchId, rentACarId: id }).toPromise();
  }

  updateAgency(agency: RentACar) {
    agency.id = parseInt(agency.id.toString());
    return this.http.put<RentACar>(this.rentACarControllerUri + agency.id, agency).toPromise();
  }

}
