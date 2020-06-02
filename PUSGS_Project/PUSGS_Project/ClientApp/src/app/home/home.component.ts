import { Component } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { BackendService } from '../services/backend.service';
import { Router } from '@angular/router';
import { AviationService } from '../services/aviation.service';
import { AviationCompany } from '../entities/aviation-company';
import { Car } from '../entities/car';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public aviationCompanies: AviationCompany[];
  public rentACarAgencies: RentACar[];
  public carsToShow: Car[];
  public isCollapsedRAC: boolean;
  public isCollapsed: boolean;
  public search: string = "";
  public displayAgencies: boolean = true;

  constructor(private RACService: RentACarService, public backend: BackendService, private aviationService: AviationService, private router: Router) {
    RACService.getAgencies().then(result => {
      this.rentACarAgencies = result;
    });
    aviationService.getAll().then(result => this.aviationCompanies = result);
    this.displayAgencies = true;
  }

  details(id: number) {
    this.router.navigateByUrl("rent-a-car/" + id);
  }
  aviationDetails(id: number) {
    this.router.navigateByUrl("aviation/" + id);
  }

  onFilterCar() {
    const searchText = this.search.toLowerCase();
    if (searchText.trim() == "") {
      this.displayAgencies = true;
    }
    else {
      this.displayAgencies = false;
    }
    this.carsToShow = [];
    this.rentACarAgencies.filter(agency => {
      agency.cars.filter(car => {
        if (car.name.toLowerCase().includes(searchText)) {
          this.carsToShow.push(car);
        }
        else if (car.type.toLowerCase().includes(searchText)) {
          this.carsToShow.push(car);
        }
        else if (car.brand.toLowerCase().includes(searchText)) {
          this.carsToShow.push(car);
        }
        else if (car.model.toLowerCase().includes(searchText)) {
          this.carsToShow.push(car);
        }
      });
    });
  }
}
