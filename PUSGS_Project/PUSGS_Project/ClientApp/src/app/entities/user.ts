export class User {

  name: string;
  lastName: string;
  city: string;
  phone: string;
  email: string;
  password: string;

  constructor(name: string, lastName: string, city: string, phone: string, email: string, password: string) {
    this.name = name;
    this.email = email;
    this.lastName = lastName;
    this.city = city;
    this.phone = phone;
    this.password = password;
  }

}
