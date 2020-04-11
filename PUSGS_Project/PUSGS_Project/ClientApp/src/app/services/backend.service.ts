import { Injectable } from "@angular/core";
import { User } from "../entities/user";

@Injectable({
  providedIn: "root",
})
export class BackendService {
  registeredUsers: User[] = [];

  constructor() {
    // Initializing mock data
    this._create_friends();
    this._create_admin();
  }

  login(email: string, password: string): [boolean, string] {
    for (var i = 0; i < this.registeredUsers.length; i++) {
      if (this.registeredUsers[i].email == email) {
        if (this.registeredUsers[i].password == password) {
          localStorage.setItem("currUser", email);
          return [true, ""];
        }
        return [false, "invalid password"];
      }
    }
    return [false, "invalid email"];
  }

  register(user: User): boolean {
    for (var i = 0; i < this.registeredUsers.length; i++) {
      if (this.registeredUsers[i].email == user.email) {
        return false;
      }
    }
    this.registeredUsers.push(user);
    return true;
  }

  isLogedIn(): boolean {
    return !!localStorage.getItem("currUser");
  }

  logout() {
    localStorage.removeItem("currUser");
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
