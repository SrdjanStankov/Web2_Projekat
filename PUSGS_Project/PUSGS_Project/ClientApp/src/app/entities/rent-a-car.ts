import { Car } from "./car";
import { Branch } from "./branch";

export class RentACar {
  id: number;
  name: string;
  address: string;
  description: string;
  // TODO: cenovnik
  cars: Car[];
  branches: Branch[];
  ratings: number[];
  averageRating: number;
}
