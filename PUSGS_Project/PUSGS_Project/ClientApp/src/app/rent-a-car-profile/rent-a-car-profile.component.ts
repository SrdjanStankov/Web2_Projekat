import { Component, OnInit } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';

@Component({
  selector: 'app-rent-a-car-profile',
  templateUrl: './rent-a-car-profile.component.html',
  styleUrls: ['./rent-a-car-profile.component.css']
})
export class RentACarProfileComponent implements OnInit {

  public rentACar: RentACar;

  constructor(private service: RentACarService) {
    this.rentACar = service.getAgency(0);
  }

  ngOnInit(): void {
  }

}
