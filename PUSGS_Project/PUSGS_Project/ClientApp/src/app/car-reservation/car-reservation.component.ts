import { Component, OnInit } from '@angular/core';
import { RentACarService } from '../services/rent-a-car.service';
import { RentACar } from '../entities/rent-a-car';
import { FormGroup, FormControl } from '@angular/forms';
import { Car } from '../entities/car';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-car-reservation',
  templateUrl: './car-reservation.component.html',
  styleUrls: ['./car-reservation.component.css']
})
export class CarReservationComponent implements OnInit {

  public step: number;

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
    costRange: new FormControl(''),
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
        if (car.PassengerNumber === this.editGroup.get('number').value) {
          if (car.Type === this.editGroup.get('type').value) {
            // and in cost range
            this.foundCars.push(car);
          }
        }
      }
    })
    this.step++;
  }

  reserve(car: Car) {
    alert(this.editGroup.get('take').get('date').value);
  }
}
