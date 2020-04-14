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

  public agencies: RentACar[];

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
    costRange: new FormControl(0),
  });

  private searchAgency: RentACar;
  public foundCars: Car[] = [];
  constructor(private service: RentACarService) {
    this.agencies = service.getAgencies();
    this.step = 1;
  }

  ngOnInit(): void {
  }

  choosedAgency(agency) {
    this.searchAgency = agency;
    this.step++;
  }

  onSubmit() {
    this.searchAgency.Cars.forEach((car) => {
      if (!car.isReserved()) {
        if (car.PassengerNumber === this.editGroup.get("number").value) {
          if (car.Type.toLowerCase() === (this.editGroup.get("type").value as string).toLowerCase()) {
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

}
