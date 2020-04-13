import { Location } from "./location";
import { Flight } from "./flight";

export class AviationCompany {
  name: string;
  address: Location;
  description: string;
  flights: Flight[];
  ratings: number[];

  /*
  TODO: Dodati:
   - destinacije na kojima posluje
   - spisak karaka sa popustima za brzu rezervaciju
   - konfiguraciju segmenata i mesta u avionima
   - cenovnik i informacije o ptrljagu
  */
}
