import { Component } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public rentACarAgencies: RentACar[];
  public isCollapsedRAC: boolean;
  public isCollapsed: boolean;

  constructor(private RACService: RentACarService) {
    RACService.getAgencies().then(result => this.rentACarAgencies = result);
  }

}
