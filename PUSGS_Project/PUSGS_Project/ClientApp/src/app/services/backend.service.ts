import { Injectable, Inject } from "@angular/core";
import { User } from "../entities/user";
import { HttpClient } from "@angular/common/http";
import { STORAGE_TOKEN_KEY } from "../constants/storage"

@Injectable({
  providedIn: "root",
})
export class BackendService {
  http: HttpClient;
  userControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.userControllerUri = baseUrl + 'api/user/';
  }

  login(email: string, password: string) {
    return this.http.post(this.userControllerUri + 'Login', { email, password }).toPromise()
  }

  register(user: User) {
    return this.http.post<User>(this.userControllerUri + 'Register', user).toPromise();
  }

  isLogedIn(): boolean {
    return !!localStorage.getItem(STORAGE_TOKEN_KEY);
  }

  logout() {
    localStorage.clear();
  }

  getLogedInUserType(): string {
    return localStorage.getItem("type");
  }

  addRentACarAdmin(admin: RentACarAdmin) {
    return this.http.post(this.userControllerUri, admin).toPromise();
  }
  
}
