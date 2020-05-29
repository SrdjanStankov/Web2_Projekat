import { Location } from "./location";
import { Flight } from "./flight";
import { Rating } from "./rating";

export class AviationCompany {
  id: number;
  name: string;
  description: string;
  address: Location;
  flights: Flight[];
  ratings: Rating[];

  get averageRating(): number {
    return 5;
  }
}
