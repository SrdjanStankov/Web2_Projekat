import { Location } from "./location";
import { Flight } from "./flight";

export class AviationCompany {
  id: number;
  name: string;
  description: string;
  address: Location = new Location();
  flights: Flight[];
  averageRating = 0;
}
