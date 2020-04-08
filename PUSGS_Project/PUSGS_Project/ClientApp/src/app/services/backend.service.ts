import { Injectable } from "@angular/core";
import { User } from "../entities/user";

@Injectable({
  providedIn: "root",
})
export class BackendService {
  registeredUsers: User[] = [];

  constructor() {
    const user = new User(
      "test name",
      "test surname",
      "test city",
      "555-333",
      "test@gmail.com",
      "test"
    );
    this.registeredUsers.push(user);
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
}
