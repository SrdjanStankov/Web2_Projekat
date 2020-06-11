import { Component, OnInit } from '@angular/core';
import { RentACar } from '../entities/rent-a-car';
import { RentACarService } from '../services/rent-a-car.service';
import { BackendService } from '../services/backend.service';
import { Router } from '@angular/router';
import { AviationService } from '../services/aviation.service';
import { AviationCompany } from '../entities/aviation-company';
import { Car } from '../entities/car';
import { Flight } from '../entities/flight';
import { CarReservation } from '../entities/car-reservation';
import { CarReservationService } from '../services/car-reservation.service';
import { STORAGE_USER_ID_KEY } from '../constants/storage';
import { FormControl, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Rating } from '../entities/rating';
import { RatingService } from '../services/rating.service';
import { getRequirePassChange } from '../util/storage';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public aviationCompanies: AviationCompany[];
  public flightsToShow: Flight[];
  public rentACarAgencies: RentACar[];
  public carReservations: CarReservation[];
  public carsToShow: Car[];
  public isCollapsedCarResHistory: boolean;
  public isCollapsedRAC: boolean;
  public isCollapsed: boolean;
  public search: string = "";
  public searchFlight: string = "";
  public displayAgencies: boolean = true;
  public displayCompanies: boolean = true;
  public rating = new FormControl(null, Validators.required);

  constructor(private RACService: RentACarService, public backend: BackendService, private aviationService: AviationService,
    private router: Router, private carReservationService: CarReservationService, private modalService: NgbModal, private ratingService: RatingService) {
  }

  public ngOnInit(): void {
    this.rerouteIfRequirePassChange();

    this.RACService.getAgencies().then(result => {
      this.rentACarAgencies = result;
    });

    this.aviationService.getAll().then(result => this.aviationCompanies = result);

    if (this.backend.isLogedIn()) {
      this.carReservationService.getReservations(localStorage.getItem(STORAGE_USER_ID_KEY)).then(result => {
        this.carReservations = result;
      });
    }
  }

  private rerouteIfRequirePassChange() {
    if (getRequirePassChange()) {
      this.router.navigate(['change-password']);
    }
  }

  checkDate(to: Date): boolean {
    return (new Date(Date.now()) >= new Date(to.toString()));
  }

  rateCar(content, reservation: CarReservation) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-add-rating' }).result.then(result => {
      const rating = new Rating();
      rating.value = Number.parseFloat(this.rating.value);
      rating.userId = reservation.ownerEmail;
      rating.carId = reservation.reservedCarId;
      rating.reservationId = reservation.id;
      this.ratingService.rateCar(rating).then(result => {
        reservation.rating = rating.value;
      });
    });
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

  onFilterFlight() {
    const searchText = this.searchFlight.toLowerCase();
    if (searchText.trim() == "") {
      this.displayCompanies = true;
    }
    else {
      this.displayCompanies = false;
    }
    this.flightsToShow = [];
    this.aviationCompanies.filter(company => {
      company.flights.filter(flight => {
        if (flight.from.cityName.toLowerCase().includes(searchText)) {
          this.flightsToShow.push(flight);
        }
        else if (flight.to.cityName.toLowerCase().includes(searchText)) {
          this.flightsToShow.push(flight);
        }
      });
    });
  }
}
