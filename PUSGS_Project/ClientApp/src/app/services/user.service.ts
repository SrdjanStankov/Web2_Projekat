import { Injectable, Inject } from '@angular/core';
import { User } from "../entities/user";
import { HttpClient } from "@angular/common/http";
import { STORAGE_USER_ID_KEY, STORAGE_TYPE_KEY } from '../constants/storage';
import { FlightTicketDetails } from '../entities/flight-ticket';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  http: HttpClient;
  userControllerUri: string;
  flightControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_USER_URL') baseUrl: string, @Inject('BASE_AVIO_URL') baseAvioUrl: string) {
    this.http = http;
    this.userControllerUri = baseUrl + 'api/user/';
    this.flightControllerUri = baseAvioUrl + 'api/flight/';
  }
  getAllUsers(): Promise<User[]> {
    return this.http.get<User[]>(this.userControllerUri).toPromise();
  }
  getLoggedInUserId(): string {
    return localStorage.getItem(STORAGE_USER_ID_KEY);
  }
  getLoggedInUserType(): string {
    return localStorage.getItem(STORAGE_TYPE_KEY);
  }
  getLoggedInUser(): Promise<User> {
    const email = localStorage.getItem(STORAGE_USER_ID_KEY);
    return this.http.get<User>(this.userControllerUri + email).toPromise();
  }
  addFriend(userId: string, friendId: string) {
    return this.http.post(this.userControllerUri + "friend", { userId, friendId }).toPromise();
  }
  unfriend(userId: string, friendId: string) {
    return this.http.post(this.userControllerUri + "unfriend", { userId, friendId }).toPromise();
  }
  deleteUser(userId) {
    return this.http.delete(this.userControllerUri + userId).toPromise();
  }
  updateUser(user: User) {
    return this.http.put(this.userControllerUri + user.email, user).toPromise();
  }
  getFlightHistory(userId: string): Promise<FlightTicketDetails[]> {
    return this.http.get<FlightTicketDetails[]>(this.flightControllerUri + userId + "/flight-history").toPromise();
  }
  changePassword(userId: string, newPassword: string) {
    return this.http.post(this.userControllerUri + `${userId}/change-password`, { newPassword }).toPromise();
  }
}
