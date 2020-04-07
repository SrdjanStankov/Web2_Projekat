import { Injectable } from '@angular/core';
import { User } from '../entities/user';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  registeredUsers: User[] = [];

  private logedInUser: User = null;

  constructor() { }

  login(email: string, password: string): [boolean, string] {
    for (var i = 0; i < this.registeredUsers.length; i++) {
      if (this.registeredUsers[i].email == email) {
        if (this.registeredUsers[i].password == password) {
          this.logedInUser = this.registeredUsers[i];
          return [true, ''];
        }
        return [false, 'invalid password'];
      }
    }
    return [false, 'invalid email'];
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
}
