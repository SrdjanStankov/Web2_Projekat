import { User } from "./user";

export class RentACarAdmin extends User {
  IsRentACarAdmin: boolean;

  constructor(
    name: string = "",
    lastName: string = "",
    city: string = "",
    phone: string = "",
    email: string = "",
    password: string = "",
    friends = []
  ) {
    super({ name: name, email: email, lastName: lastName, city: city, phone: phone, password: password, friends: friends });
    this.IsRentACarAdmin = true;
  }
}
