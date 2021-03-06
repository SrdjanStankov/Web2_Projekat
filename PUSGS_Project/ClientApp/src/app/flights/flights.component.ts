import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { Flight } from '../entities/flight';
import { Router } from '@angular/router';
import { msToTimeString } from '../util/time';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {
  allFlights: Flight[];
  displayedFlights: Flight[];
  search = "";
  from = "";
  to = "";

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

  getTravelTime(flight: Flight): string {
    const diff = new Date(flight.arrivalTime).valueOf() - new Date(flight.departureTime).valueOf();
    return msToTimeString(Math.abs(diff));
  }

  // Filter
  onApplyFilter() {
    let query = this.allFlights;

    this.search.split(',').forEach(str => {
      const search = str.toLowerCase().trim();
      if (search) {
        query = this.filterBySearchText(query, search);
      }
    })

    if (this.from) {
      query = this.filterByFromDate(query, this.from);
    }
    if (this.to) {
      query = this.filterByToDate(query, this.to);
    }

    this.displayedFlights = query;
  }

  private filterBySearchText(query: Flight[], search = ""): Flight[] {
    return query.filter(flight => {
      return flight.aviationCompanyName.toLowerCase().includes(search)
        || flight.from.cityName.toLowerCase().includes(search)
        || flight.to.cityName.toLowerCase().includes(search)
        || flight.ticketPrice.toString() === search
        || flight.travelLength.toString() === search;
    });
  }

  private filterByFromDate(query: Flight[], dateStr = ""): Flight[] {
    try {
      const date = new Date(dateStr);
      console.log("from", date);
      return query.filter(flight => new Date(flight.departureTime).getTime() >= date.getTime());
    } catch (ex) {
      console.warn(ex);
    }
    return query;
  }

  private filterByToDate(query: Flight[], dateStr = ""): Flight[] {
    try {
      const date = new Date(dateStr);
      console.log("to", date);
      return query.filter(flight => new Date(flight.departureTime).getTime() <= date.getTime());
    } catch (ex) {
      console.warn(ex);
    }
    return query;
  }
}
