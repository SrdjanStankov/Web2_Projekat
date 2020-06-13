import { Component, OnInit } from '@angular/core';
import { CarReservation } from '../entities/car-reservation';
import { BackendService } from '../services/backend.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CarReservationService } from '../services/car-reservation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Car } from '../entities/car';
import { CarService } from '../services/car.service';
import { STORAGE_USER_ID_KEY } from '../constants/storage';

@Component({
  selector: 'app-quick-car-reservation',
  templateUrl: './quick-car-reservation.component.html',
  styleUrls: ['./quick-car-reservation.component.css']
})
export class QuickCarReservationComponent implements OnInit {
  public rangeVal = 0;
  quickTickets: CarReservation[];
  cars: Car[];
  rentACarAgencyId: number;
  selectedCar: Car;

  public editGroup = new FormGroup({
    take: new FormGroup({
      date: new FormControl('', Validators.required),
    }),
    return: new FormGroup({
      date: new FormControl('', Validators.required),
    }),
    discount: new FormControl(0),
  });

  constructor(public backend: BackendService, private carReservationService: CarReservationService, private route: ActivatedRoute, private modalService: NgbModal,
  private carService: CarService, private router: Router) {
    route.params.subscribe(params => { this.rentACarAgencyId = params['id']; });
  }

  ngOnInit(): void {
    // get tickets with discounts
    this.carReservationService.getQuickReservations(this.rentACarAgencyId).then(result => {
      this.quickTickets = result;
    });

    this.carService.getCars(this.rentACarAgencyId, null, null, null, null, null, "true").then(result => {
      this.cars = result;
    });
  }

  valueChanged(value) {
    this.rangeVal = value;
  }

  selectCar(car: Car) {
    this.selectedCar = car;
  }

  onReserve(ticket: CarReservation) {
    ticket.ownerEmail = localStorage.getItem(STORAGE_USER_ID_KEY);
    this.carReservationService.updateReservationWithUser(ticket).then(result => {
      this.router.navigateByUrl("");
    })
  }

  onAddClick(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-quick-reservation' }).result.then(result => {

    });
  }

  onSubmit() {
    // add new car reservation without user
    var ret = this.editGroup.get("return").get("date").value;
    var take = this.editGroup.get("take").get("date").value;
    const reservation = new CarReservation();
    reservation.dateCreated = new Date(Date.now());
    reservation.from = new Date(take.year, take.month - 1, take.day);
    reservation.to = new Date(ret.year, ret.month - 1, ret.day);
    reservation.reservedCarId = this.selectedCar.id;
    reservation.discount = Number.parseInt(this.editGroup.get('discount').value)
    this.carReservationService.reserveCar(reservation).then(res => {
      location.reload(true);
    })
  }

}
