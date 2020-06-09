export class Location {
  x: number;
  y: number;
  cityName: string;

  constructor({ x = 0, y = 0, cityName = "" } = {}) {
    this.x = x;
    this.y = y;
    this.cityName = cityName;
  }
}
