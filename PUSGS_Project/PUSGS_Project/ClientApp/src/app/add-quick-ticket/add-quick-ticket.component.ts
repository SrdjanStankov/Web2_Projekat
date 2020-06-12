import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Flight } from '../entities/flight';
import { FlightSeat } from '../entities/flight-seat';
import { FlightTicket } from '../entities/flight-ticket';

@Component({
  selector: 'app-add-quick-ticket',
  templateUrl: './add-quick-ticket.component.html',
  styleUrls: ['./add-quick-ticket.component.css']
})
export class AddQuickTicketComponent implements OnInit {
  private aviationId: number;
  flights: Flight[];
  numPages = 2;
  currPageIndex = 0;

  // Step 1
  selectedFlight: Flight;

  // Step 2
  flightSeats: FlightSeat[];
  selectedSeatId = "";
  discount = 0;

  constructor(private flightService: FlightService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.aviationId = Number.parseInt(params['id']);
    });
    this.flightService.getAll().then(flights => {
      this.flights = flights;
      this.flights = this.flights.filter(f => f.aviationCompanyId === this.aviationId);
    })
  }

  // Step 1
  chooseFlight(flight: Flight) {
    this.selectedFlight = flight;
    this.flightSeats = flight.seats;
    this.flightService.get(flight.id).then(flightDetails => {
      this.flightSeats = flightDetails.seats.sort((a, b) => a.seatNumber - b.seatNumber);
      this.next();
    });
  }

  // Step 2
  onSeatSelectChange(seatId: string) {
    this.selectedSeatId = seatId;
  }

  onDiscountChange(value) {
    this.discount = Number.parseFloat(value);
  }

  canSubmit(): boolean {
    return !!this.selectedSeatId && !!this.discount;
  }

  submit() {
    const ticket = new FlightTicket({
      flightId: this.selectedFlight.id,
      flightSeatId: Number.parseInt(this.selectedSeatId),
      discount: this.discount
    });

    this.flightService.makeReservation(ticket).then(() => {
      console.log("Created quick reservation");
      this.router.navigateByUrl(`aviation/${this.aviationId}/quick-reservations`);
    });
  }

  //Form navigation
  back() {
    if (this.currPageIndex - 1 < 0)
      return;

    this.currPageIndex--;
  }

  next() {
    if (this.currPageIndex + 1 >= this.numPages)
      return;

    this.currPageIndex++;
  }
}
