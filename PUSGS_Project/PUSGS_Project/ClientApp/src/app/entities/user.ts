import { FlightTicket } from "./flight-ticket";

export class User {
  name: string;
  lastName: string;
  city: string;
  phone: string;
  email: string;
  password: string;
  friends: string[]; // friend userId's (emails)
  flightTickets: FlightTicket[];

  constructor(
    {
      name = "",
      lastName = "",
      city = "",
      phone = "",
      email = "",
      password = "",
      friends = []
    } = {}
  ) {
    this.name = name;
    this.email = email;
    this.lastName = lastName;
    this.city = city;
    this.phone = phone;
    this.password = password;
    this.friends = friends;
  }

  get id(): string {
    return this.email;
  }
}
