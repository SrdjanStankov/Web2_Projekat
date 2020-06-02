import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { Flight } from '../entities/flight';
import { Router } from '@angular/router';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  allFlights: Flight[];
  displayedFlights: Flight[];

  constructor(public flightService: FlightService, private router: Router) { }

  ngOnInit(): void {
    this.flightService.getAll().then(items => {
      this.allFlights = items;
      this.displayedFlights = this.allFlights;
      console.log("Loaded flights", this.allFlights);
    });
  }

  flightDetails(flightId: number) {
    this.router.navigateByUrl("flight/" + flightId);
  }
}
