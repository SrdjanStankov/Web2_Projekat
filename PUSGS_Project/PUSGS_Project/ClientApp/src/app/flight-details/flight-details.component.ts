import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FlightService } from '../services/flight.service';
import { Flight } from '../entities/flight';

@Component({
  selector: 'app-flight-details',
  templateUrl: './flight-details.component.html',
  styleUrls: ['./flight-details.component.css']
})
export class FlightDetailsComponent implements OnInit {
  flight: Flight;
  id: number;

  constructor(private service: FlightService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.id = params['id']; });
    this.service.get(this.id).then(result => {
      this.flight = result;
    });
  }

  openReservationForm(): void {
    this.router.navigateByUrl(`flight/${this.id}/reservation`);
  }

  canMakeReservation(): boolean {
    return this.flight.seats.some(s => !s.isReserved);
  }
}
