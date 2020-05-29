import { Component } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { BackendService } from '../services/backend.service';
import { Router } from '@angular/router';
import { AviationService } from '../services/aviation.service';
import { AviationCompany } from '../entities/aviation-company';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public aviationCompanies: AviationCompany[];
  public rentACarAgencies: RentACar[];
  public isCollapsedRAC: boolean;
  public isCollapsed: boolean;

  constructor(private RACService: RentACarService, public backend: BackendService, private aviationService: AviationService, private router: Router) {
    RACService.getAgencies().then(result => this.rentACarAgencies = result);
    aviationService.getAll().then(result => this.aviationCompanies = result);
  }

  details(id: number) {
    this.router.navigateByUrl("rent-a-car/" + id);
  }
  aviationDetails(id: number) {
    this.router.navigateByUrl("aviation/" + id);
  }
}
