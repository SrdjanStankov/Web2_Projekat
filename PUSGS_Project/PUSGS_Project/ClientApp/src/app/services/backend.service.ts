import { Injectable, Inject } from "@angular/core";
import { User } from "../entities/user";
import { HttpClient } from "@angular/common/http";
import { STORAGE_TOKEN_KEY, STORAGE_TYPE_KEY } from "../constants/storage"
import { SocialUser } from "angularx-social-login";
import { Router } from "@angular/router";
import { RentACarAdmin } from "../entities/RentACarAdmin";
import { AviationAdmin } from "../entities/AviationAdmin";

@Injectable({
  providedIn: "root",
})
export class BackendService {
  http: HttpClient;
  userControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.http = http;
    this.userControllerUri = baseUrl + 'api/user/';
  }

  login(email: string, password: string) {
    return this.http.post(this.userControllerUri + 'Login', { email, password }).toPromise()
  }

  loginScial(user: SocialUser) {
    return this.http.post(this.userControllerUri + 'SocialLogin', user).toPromise();
  }

  register(user: User) {
    return this.http.post<User>(this.userControllerUri + 'Register', user).toPromise();
  }

  isLogedIn(): boolean {
    return !!localStorage.getItem(STORAGE_TOKEN_KEY);
  }

  logout() {
    localStorage.clear();
    this.router.navigate([""]);
  }

  getLogedInUserType(): string {
    return localStorage.getItem(STORAGE_TYPE_KEY);
  }

  addRentACarAdmin(admin: RentACarAdmin) {
    return this.http.post(this.userControllerUri + "Register", admin).toPromise();
  }

  addAviationAdmin(admin: AviationAdmin) {
    return this.http.post(this.userControllerUri + "Register", admin).toPromise();
  }

  confirmEmail(email: string) {
    return this.http.post<string>(this.userControllerUri + "ConfirmEmail", { email }).toPromise();
  }
}
