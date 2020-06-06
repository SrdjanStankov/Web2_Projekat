import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { ActivatedRoute } from '@angular/router';
import { Flight } from '../entities/flight';
import { FlightSeatSelectedEventArgs } from '../flight-seat/flight-seat.component';
import { FlightSeat } from '../entities/flight-seat';
import { FlightTicket } from '../entities/flight-ticket';
import { UserService } from '../services/user.service';
import { User } from '../entities/user';

@Component({
  selector: 'app-flight-reservation-form',
  templateUrl: './flight-reservation-form.component.html',
  styleUrls: ['./flight-reservation-form.component.css']
})
export class FlightReservationFormComponent implements OnInit {
  private id;
  flight: Flight;
  currUser: User;

  private numPages = 3;
  currPageIndex = 0;

  // Step 1
  selectedSeats: FlightSeat[] = [];

  // Step 2
  currUserSeatId: string;
  currUserTicket: FlightTicket = new FlightTicket();

  // Step 3
  friendTickets: FlightTicket[] = [];

  constructor(private service: FlightService, private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.id = params['id']; });
    this.service.get(this.id).then(flight => {
      this.flight = flight;
      this.currUserTicket.flightId = flight.id;
    });
    this.userService.getLoggedInUser().then(user => {
      this.currUser = user;
      this.currUserTicket.ticketOwnerEmail = user.email;
    })
  }

  onSeatSelectedChange(args: FlightSeatSelectedEventArgs) {
    const seat = args.seat;
    if (!seat)
      return;
    if (args.selected) {
      this.selectedSeats.push(seat);
    } else {
      this.selectedSeats = this.selectedSeats.filter(s => s.id !== seat.id);
      this.clearNextStepIfFaulted(seat);
    }
  }

  private clearNextStepIfFaulted(unselectedSeat: FlightSeat) {
    if (unselectedSeat.id.toString() === this.currUserSeatId) {
      this.currUserSeatId = "-1";
      this.currUserTicket.flightSeatId = -1;
    }
  }

  onCurrUserSeatChange(seatId: number) {
    this.currUserSeatId = seatId.toString();
    this.currUserTicket.flightSeatId = seatId;
    console.log("seatId: ", seatId);
  }

  submit() {
    window.alert("TODO: Submit form to back-end & re-route to home");

    console.group("Submit variables");
    console.log("selectedSeats", this.selectedSeats);
    console.log("currUserTicket", this.currUserTicket);
    console.log("friendTickets", this.friendTickets);
    console.groupEnd();
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
}
