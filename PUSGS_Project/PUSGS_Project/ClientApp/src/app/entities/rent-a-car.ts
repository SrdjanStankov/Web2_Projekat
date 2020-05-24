import { Car } from "./car";

export class RentACar {
  id: number;
  name: string;
  address: string;
  description: string;
  // TODO: cenovnik
  cars: Car[];
  branches: string[];
  ratings: number[];
}
