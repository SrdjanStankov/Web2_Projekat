import { Injectable, Inject } from "@angular/core";
import { User } from "../entities/user";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class BackendService {
  registeredUsers: User[] = [];
    http: HttpClient;
    userControllerUri: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.userControllerUri = baseUrl + 'api/user/';

    // Initializing mock data
    this._create_friends();
    this._create_admin();
  }

  login(email: string, password: string) {
    //for (var i = 0; i < this.registeredUsers.length; i++) {
    //  if (this.registeredUsers[i].email == email) {
    //    if (this.registeredUsers[i].password == password) {
    //      localStorage.setItem("currUser", email);
    //      return [true, ""];
    //    }
    //    return [false, "invalid password"];
    //  }
    //}
    //return [false, "invalid email"];

    return this.http.post(this.userControllerUri + 'Login', { email, password }).toPromise();
  }

  register(user: User) {

    //for (var i = 0; i < this.registeredUsers.length; i++) {
    //  if (this.registeredUsers[i].email == user.email) {
    //    return false;
    //  }
    //}
    return this.http.post<User>(this.userControllerUri + 'Register', user).toPromise();
    //this.registeredUsers.push(user);
  }

  isLogedIn(): boolean {
    return !!localStorage.getItem("token");
  }

  logout() {
    localStorage.removeItem("token");
  }

  getLoggedInUser(): User {
    const email = localStorage.getItem("currUser");
    return this.registeredUsers.find((user) => user.email === email);
  }

  getAllUsers(): User[] {
    return [...this.registeredUsers];
  }
  // Init helper methods
  private _create_admin() {
    this.registeredUsers.push(
      new User(
        "admin name",
        "admin surname",
        "admin city",
        "911-192",
        "admin@gmail.com",
        "admin"
      )
    );
  }
  private _create_friends() {
    const user = new User(
      "test name",
      "test surname",
      "test city",
      "555-333",
      "test@gmail.com",
      "test"
    );
    const friend = new User(
      "friend name",
      "friend surname",
      "friend city",
      "420-69",
      "friend@gmail.com",
      "friend"
    );
    user.friends.push(friend);
    friend.friends.push(user);
    this.registeredUsers.push(user);
    this.registeredUsers.push(friend);
  }
}
