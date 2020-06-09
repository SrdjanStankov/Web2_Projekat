import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FlightService } from '../services/flight.service';
import { AddFlightRequest } from '../entities/requests/add-flight-request';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '../entities/location';

@Component({
  selector: 'app-add-flight-form',
  templateUrl: './add-flight-form.component.html',
  styleUrls: ['./add-flight-form.component.css']
})
export class AddFlightFormComponent implements OnInit {
  aviationCompanyId: number;

  flightGroup = new FormGroup({
    departureTime: new FormControl(new Date(), Validators.required),
    arrivalTime: new FormControl(new Date(), Validators.required),
    travelLength: new FormControl(8, Validators.required),
    ticketPrice: new FormControl(15, Validators.required),
    numberOfChangeovers: new FormControl(2, Validators.required),
    fromCity: new FormControl('Belgrade', Validators.required),
    toCity: new FormControl('London', Validators.required),
    numberOfSeats: new FormControl(20, Validators.required),
    maxSeatsPerRow: new FormControl(4, Validators.required)
  });

  reason: string;

  constructor(private flightService: FlightService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.aviationCompanyId = Number.parseInt(params['id']); });
  }

  isInvalid(name): boolean {
    return this.flightGroup.get(name).invalid && this.flightGroup.get(name).touched;
  }

  onSubmit() {
    const request = new AddFlightRequest();
    request.aviationCompanyId = this.aviationCompanyId;
    request.departureTime = new Date(this.flightGroup.get('departureTime').value);
    request.arrivalTime = new Date(this.flightGroup.get('arrivalTime').value);
    request.travelLength = Number.parseFloat(this.flightGroup.get('travelLength').value);
    request.ticketPrice = Number.parseFloat(this.flightGroup.get('ticketPrice').value);
    request.numberOfChangeovers = Number.parseInt(this.flightGroup.get('numberOfChangeovers').value);
    request.from = new Location({ cityName: this.flightGroup.get('fromCity').value });
    request.to = new Location({ cityName: this.flightGroup.get('toCity').value });
    request.numberOfSeats = Number.parseInt(this.flightGroup.get('numberOfSeats').value);
    request.maxSeatsPerRow = Number.parseInt(this.flightGroup.get('maxSeatsPerRow').value);

    this.flightService.add(request).then(() => {
      this.router.navigateByUrl(`flights`);
    });
  }
}
