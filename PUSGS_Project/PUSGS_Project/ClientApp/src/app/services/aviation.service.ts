import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { AviationCompany } from '../entities/aviation-company';
import { AddOrUpdateAviationCompanyRequest } from '../entities/requests/add-or-update-aviation-company-request';

@Injectable({
  providedIn: 'root'
})
export class AviationService {
  http: HttpClient;
  aviationControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.aviationControllerUri = baseUrl + 'api/aviation/';
  }
  getAll(): Promise<AviationCompany[]> {
    return this.http.get<AviationCompany[]>(this.aviationControllerUri).toPromise();
  }
  get(id: number): Promise<AviationCompany> {
    return this.http.get<AviationCompany>(this.aviationControllerUri + id).toPromise();
  }
  add(request: AddOrUpdateAviationCompanyRequest) {
    return this.http.post(this.aviationControllerUri, request).toPromise();
  }
  update(request: AddOrUpdateAviationCompanyRequest) {
    return this.http.post(this.aviationControllerUri + request.id, request).toPromise();
  }
  delete(id: number) {
    return this.http.delete(this.aviationControllerUri + id).toPromise();
  }
}
