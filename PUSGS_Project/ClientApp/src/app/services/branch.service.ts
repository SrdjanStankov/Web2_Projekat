import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Branch } from '../entities/branch';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  http: HttpClient;
  branchControllerUri: string;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.http = http;
    this.branchControllerUri = baseUrl + "api/branch/";
  }

  addBranch(branch: Branch) {
    return this.http.post<Branch>(this.branchControllerUri, branch).toPromise();
  }

  removeBranch(id: number) {
    return this.http.delete<Branch>(this.branchControllerUri + id).toPromise();
  }

  updateBranch(branch: Branch) {
    return this.http.put<Branch>(this.branchControllerUri + branch.id, branch).toPromise();
  }

  getBranch(id: number) {
    return this.http.get<Branch>(this.branchControllerUri + id).toPromise();
  }
}
