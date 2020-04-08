import { Injectable } from "@angular/core";
import { User } from "../entities/user";

@Injectable({
  providedIn: "root",
})
export class BackendService {
  registeredUsers: User[] = [];

  private logedInUser: User = null;

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
          this.logedInUser = this.registeredUsers[i];
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
    return this.logedInUser != null;
  }

  logout() {
    this.logedInUser = null;
  }

  getLoggedInUser(): User {
    return this.logedInUser;
  }
}
