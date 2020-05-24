import { Component } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { BackendService } from '../services/backend.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public rentACarAgencies: RentACar[];
  public isCollapsedRAC: boolean;
  public isCollapsed: boolean;

  constructor(private RACService: RentACarService, public backend: BackendService, private router: Router) {
    RACService.getAgencies().then(result => this.rentACarAgencies = result);
  }

  details(id: number) {
    this.router.navigateByUrl("rent-a-car/" + id);
  }

}
