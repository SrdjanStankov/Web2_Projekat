import { Component, OnInit } from '@angular/core';
import { RentACarService } from '../services/rent-a-car.service';
import { RentACar } from '../entities/rent-a-car';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Car } from '../entities/car';
import { CarService } from '../services/car.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CarReservationService } from '../services/car-reservation.service';
import { CarReservation } from '../entities/car-reservation';
import { STORAGE_USER_ID_KEY } from '../constants/storage';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

const now: Date = new Date(Date.now());

@Component({
  selector: 'app-car-reservation',
  templateUrl: './car-reservation.component.html',
  styleUrls: ['./car-reservation.component.css']
})
export class CarReservationComponent implements OnInit {
  public step: number;
  public rangeVal = 0;
  public addressFilter = "";
  public search: string = "";
  minDate: NgbDateStruct = { year: now.getFullYear(), month: now.getMonth() + 1, day: now.getDate() };

  public allAgencies: RentACar[];
  public displayAgencies: RentACar[];

  public editGroup = new FormGroup({
    take: new FormGroup({
      date: new FormControl('', Validators.required),
      location: new FormControl('', Validators.required),
    }),
    return: new FormGroup({
      date: new FormControl('', Validators.required),
      location: new FormControl('', Validators.required),
    }),
    type: new FormControl('', Validators.required),
    number: new FormControl('', Validators.required),
    costRange: new FormControl(2000),
  });

  private searchAgency: RentACar;
  public foundCars: Car[] = [];

  constructor(private rentACarService: RentACarService, private carService: CarService,
    private route: ActivatedRoute,
    private router: Router, private carReservationService: CarReservationService) { }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(map => {
      this.addressFilter = map.get("address") || "";
      this.addressFilter = this.addressFilter.toLowerCase();
    });

    this.rentACarService.getAgencies().then(result => {
      this.allAgencies = result;
      this.onFilter();
    });

    this.step = 1;
    this.valueChanged(2000);
  }

  choosedAgency(agency) {
    this.searchAgency = agency;
    this.step++;
  }

  onSubmit() {
    const retDate = this.editGroup.get("return").get("date").value;
    const takeDate = this.editGroup.get("take").get("date").value;

    this.carService.getCars(this.searchAgency.id,
      this.editGroup.get("number").value,
      this.editGroup.get("type").value,
      (new Date(retDate.year, retDate.month - 1, retDate.day)).toUTCString(),
      (new Date(takeDate.year, takeDate.month - 1, takeDate.day)).toUTCString(),
      this.editGroup.get("costRange").value).then(result => {
        this.foundCars = result;
        this.step++;
      });
  }

  reserve(car: Car) {
    var ret = this.editGroup.get("return").get("date").value;
    var take = this.editGroup.get("take").get("date").value;
    const reservation = new CarReservation();
    reservation.dateCreated = new Date(Date.now());
    reservation.from = new Date(take.year, take.month - 1, take.day);
    reservation.to = new Date(ret.year, ret.month - 1, ret.day);
    reservation.ownerEmail = localStorage.getItem(STORAGE_USER_ID_KEY);
    reservation.reservedCarId = car.id;
    reservation.costForRange = car.costForRange;
    this.carReservationService.reserveCar(reservation).then(result => {
      location.reload(true);
    }, err => {
      if (err.status === 400) {
        alert(err.error.message);
      }
    });
  }

  valueChanged(e) {
    this.rangeVal = e;
  }

  onFilter() {
    const searchText = this.search.toLowerCase();
    let query = this.allAgencies;

    if (this.addressFilter) {
      query = query.filter(agency => {
        return agency.branches.some(branch => branch.address.toLowerCase().includes(this.addressFilter));
      });
    }

    this.displayAgencies = query.filter((agency) => {
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
