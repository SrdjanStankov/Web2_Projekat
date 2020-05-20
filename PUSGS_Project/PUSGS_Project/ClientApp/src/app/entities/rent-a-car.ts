import { Car } from "./car";

export class RentACar {
  Id: number;
  Name: string;
  Address: string;
  Description: string;
  // TODO: cenovnik
  Cars: Car[];
  Branches: string[];
  Ratings: number[];
}
