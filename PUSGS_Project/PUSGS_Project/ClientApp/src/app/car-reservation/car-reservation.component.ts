import { Component, OnInit } from '@angular/core';
import { RentACarService } from '../services/rent-a-car.service';
import { RentACar } from '../entities/rent-a-car';
import { FormGroup, FormControl } from '@angular/forms';
import { Car } from '../entities/car';

@Component({
  selector: 'app-car-reservation',
  templateUrl: './car-reservation.component.html',
  styleUrls: ['./car-reservation.component.css']
})
export class CarReservationComponent implements OnInit {

  public step: number;
  public rangeVal = 0;
  public search: string = "";

  public allAgencies: RentACar[];
  public displayAgencies: RentACar[];

  public editGroup = new FormGroup({
    take: new FormGroup({
      date: new FormControl(''),
      location: new FormControl(''),
    }),
    return: new FormGroup({
      date: new FormControl(''),
      location: new FormControl(''),
    }),
    type: new FormControl(''),
    number: new FormControl(''),
    costRange: new FormControl(2000),
  });

  private searchAgency: RentACar;
  public foundCars: Car[] = [];
  constructor(private service: RentACarService) {
    service.getAgencies().then(result => this.allAgencies = result);
    this.displayAgencies = this.allAgencies;
    this.step = 1;
    this.valueChanged(2000);
  }

  ngOnInit(): void {
  }

  choosedAgency(agency) {
    this.searchAgency = agency;
    this.step++;
  }

  onSubmit() {
    this.searchAgency.cars.forEach((car) => {
      if (!car.isReserved()) {
        if (car.passengerNumber === this.editGroup.get("number").value) {
          if (car.type.toLowerCase() === (this.editGroup.get("type").value as string).toLowerCase()) {
            var ret = this.editGroup.get("return").get("date").value;
            var take = this.editGroup.get("take").get("date").value
            if (car.calculateCostForRange(new Date(ret.year, ret.month, ret.day), new Date(take.year, take.month, take.day)) <+ this.editGroup.get("costRange").value) {
              this.foundCars.push(car);
            }
          }
        }
      }
    })
    this.step++;
  }

  reserve(car: Car) {
    var ret = this.editGroup.get("return").get("date").value;
    var take = this.editGroup.get("take").get("date").value;
    car.reserveCar(new Date(take.year, take.month, take.day), new Date(ret.year, ret.month, ret.day));
  }

  calculateCostForRange(car: Car) {
    var ret = this.editGroup.get("return").get("date").value;
    var take = this.editGroup.get("take").get("date").value;
    var gg = new Date(ret.year, ret.month, ret.day);
    var hh = new Date(take.year, take.month, take.day);
    return car.calculateCostForRange(gg, hh);
  }

  valueChanged(e) {
    this.rangeVal = e;
  }

  onFilter() {
    const searchText = this.search.toLowerCase();
    this.displayAgencies = this.allAgencies.filter((agency) => {
      if (agency.name.toLowerCase().includes(searchText)) {
        return true;
      }
      if (agency.address.toLowerCase().includes(searchText)) {
        return true;
      }
      return false;
    })
  }

}
