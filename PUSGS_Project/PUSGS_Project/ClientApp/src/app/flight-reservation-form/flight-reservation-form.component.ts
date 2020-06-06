import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { ActivatedRoute } from '@angular/router';
import { Flight } from '../entities/flight';
import { FlightSeatSelectedEventArgs } from '../flight-seat/flight-seat.component';

@Component({
  selector: 'app-flight-reservation-form',
  templateUrl: './flight-reservation-form.component.html',
  styleUrls: ['./flight-reservation-form.component.css']
})
export class FlightReservationFormComponent implements OnInit {
  private id;
  flight: Flight;

  private numPages = 3;
  currPageIndex = 0;

  constructor(private service: FlightService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.id = params['id']; });
    this.service.get(this.id).then(result => {
      this.flight = result;
    });
  }

  next() {
    if (this.currPageIndex + 1 >= this.numPages)
      return;

    this.currPageIndex++;
  }

  back() {
    if (this.currPageIndex - 1 < 0)
      return;

    this.currPageIndex--;
  }

  onSeatSelectedChange(args: FlightSeatSelectedEventArgs) {
    console.log(args);
  }

  submit() {
    // TODO: Submit form to back-end & re-route to home
    window.alert("Form submited");
  }
}
