import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FlightService } from '../services/flight.service';
import { Flight } from '../entities/flight';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UpdateFlightRequest } from '../entities/requests/update-flight-request';

@Component({
  selector: 'app-flight-details',
  templateUrl: './flight-details.component.html',
  styleUrls: ['./flight-details.component.css']
})
export class FlightDetailsComponent implements OnInit {
  flight: Flight;
  id: number;

  constructor(private service: FlightService, private route: ActivatedRoute,
    private router: Router, private modalService: NgbModal) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.id = params['id']; });
    this.service.get(this.id).then(result => {
      this.flight = result;
    });
  }

  deleteFlight() {
    this.service.delete(this.id).then(() => {
      this.router.navigateByUrl("");
    })
  }

  // Edit flight form
  flightGroup = new FormGroup({
    departureTime: new FormControl(new Date(), Validators.required),
    arrivalTime: new FormControl(new Date(), Validators.required),
    travelLength: new FormControl(8, Validators.required),
    ticketPrice: new FormControl(15, Validators.required),
    numberOfChangeovers: new FormControl(2, Validators.required)
  });

  openFlightModal(content) {
    this.setGroup(this.flight);

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      console.log(`Closed with: ${result}`);
      this.onUpdate();
    }, (reason) => {
      console.log(`Dismissed ${reason}`);
    });
  }

  isInvalid(name: string): boolean {
    return this.flightGroup.get(name).invalid && this.flightGroup.get(name).touched;
  }

  private setGroup(flight: Flight) {
    this.flightGroup.setValue({
      departureTime: flight.departureTime,
      arrivalTime: flight.arrivalTime,
      travelLength: flight.travelLength,
      ticketPrice: flight.ticketPrice,
      numberOfChangeovers: flight.numberOfChangeovers
    });
  }

  private onUpdate() {
    const request = new UpdateFlightRequest();
    request.departureTime = new Date(this.flightGroup.get('departureTime').value);
    request.arrivalTime = new Date(this.flightGroup.get('arrivalTime').value);
    request.travelLength = Number.parseFloat(this.flightGroup.get('travelLength').value);
    request.ticketPrice = Number.parseFloat(this.flightGroup.get('ticketPrice').value);
    request.numberOfChangeovers = Number.parseInt(this.flightGroup.get('numberOfChangeovers').value);

    this.service.update(this.flight.id, request).then(() => {
      window.location.reload();
    })
  }

  canEditFlight(): boolean {
    return !this.flight.seats.some(s => s.isReserved);
  }

  // Flight Reservation
  openReservationForm(): void {
    this.router.navigateByUrl(`flight/${this.id}/reservation`);
  }

  canMakeReservation(): boolean {
    return this.flight.seats.some(s => !s.isReserved);
  }
}
