import { Car } from "./car";

export interface RentACar {
  id: number;
  name: string;
  address: string;
  description: string;
  // TODO: cenovnik
  cars: Car[];
  branches: string[];
  ratings: number[];
}
