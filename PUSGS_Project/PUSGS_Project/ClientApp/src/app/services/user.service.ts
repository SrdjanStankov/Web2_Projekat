import { Injectable, Inject } from '@angular/core';
import { User } from "../entities/user";
import { HttpClient } from "@angular/common/http";
import { STORAGE_USER_ID_KEY } from '../constants/storage';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  http: HttpClient;
  userControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.userControllerUri = baseUrl + 'api/user/';
  }
  getAllUsers(): Promise<User[]> {
    return this.http.get<User[]>(this.userControllerUri).toPromise();
  }
  getLoggedInUserId(): string {
    return localStorage.getItem(STORAGE_USER_ID_KEY);
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
}
