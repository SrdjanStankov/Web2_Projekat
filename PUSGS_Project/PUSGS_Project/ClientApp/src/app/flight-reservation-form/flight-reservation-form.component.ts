import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { ActivatedRoute } from '@angular/router';
import { Flight } from '../entities/flight';
import { FlightSeatSelectedEventArgs } from '../flight-seat/flight-seat.component';
import { FlightSeat } from '../entities/flight-seat';
import { FlightTicket } from '../entities/flight-ticket';
import { UserService } from '../services/user.service';
import { User } from '../entities/user';
import { FlightSeatReservation } from "./helpers/flight-seat-reservation"

@Component({
  selector: 'app-flight-reservation-form',
  templateUrl: './flight-reservation-form.component.html',
  styleUrls: ['./flight-reservation-form.component.css']
})
export class FlightReservationFormComponent implements OnInit {
  private flightId;
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
  seatReservations: FlightSeatReservation[];
  availableFriendEmails: string[];
  friendTickets: FlightTicket[] = [];

  constructor(private service: FlightService, private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.flightId = params['id']; });
    this.service.get(this.flightId).then(flight => {
      this.flight = flight;
      this.currUserTicket.flightId = flight.id;
    });
    this.userService.getLoggedInUser().then(user => {
      this.currUser = user;
      this.currUserTicket.ticketOwnerEmail = user.email;
    })
  }

  // Step 1
  onSeatSelectedChange(args: FlightSeatSelectedEventArgs) {
    const seat = args.seat;
    if (!seat)
      return;
    if (args.selected) {
      this.selectedSeats.push(seat);
    } else {
      this.selectedSeats = this.selectedSeats.filter(s => s.id !== seat.id);
    }
  }

  selectSeatPrep() {
    this.currUserSeatId = "-1";
    this.currUserTicket.flightSeatId = -1;
    this.selectedSeats = this.selectedSeats.sort((a, b) => a.seatNumber - b.seatNumber);
    this.next();
  }

  // Step 2
  onCurrUserSeatChange(seatId: number) {
    this.currUserSeatId = seatId.toString();
    this.currUserTicket.flightSeatId = seatId;
  }

  inviteFriendsPrep() {
    const availableSeats = this.selectedSeats.filter(s => s.id.toString() !== this.currUserSeatId);
    this.seatReservations = availableSeats.map(seat => this.makeSeatReservation(seat));
    this.availableFriendEmails = [...this.currUser.friends];
    this.next();
  }

  private makeSeatReservation(seat: FlightSeat, ticketOwnerEmail = ""): FlightSeatReservation {
    return new FlightSeatReservation({
      flightId: this.flight.id,
      flightSeatId: seat.id,
      flightSeatNumber: seat.seatNumber,
      ticketOwnerEmail: ticketOwnerEmail
    });
  }

  // Step 3
  chooseFriend(reservation: FlightSeatReservation) {
    // TODO: Open choose friend modal window
    console.log(reservation);
  }
  freeFriend(reservation: FlightSeatReservation) {
    this.availableFriendEmails.push(reservation.ticketOwnerEmail);
    reservation.ticketOwnerEmail = "";
  }

  cancelReservation(reservation: FlightSeatReservation) {
    this.freeFriend(reservation);
    this.seatReservations = this.seatReservations.filter(r => r.flightSeatId !== reservation.flightSeatId);
  }

  allSeatsReserved(): boolean {
    return this.seatReservations.length === 0 || !this.seatReservations.some(r => !r.ticketOwnerEmail);
  }

  submit() {
    window.alert("TODO: Submit form to back-end & re-route to home");

    this.friendTickets = this.seatReservations.map(r => this.makeFlightTicket(r));

    console.group("Submit variables");
    console.log("currUserTicket", this.currUserTicket);
    console.log("friendTickets", this.friendTickets);
    console.groupEnd();
  }

  private makeFlightTicket(reservation: FlightSeatReservation): FlightTicket {
    return new FlightTicket({
      flightId: reservation.flightId,
      flightSeatId: reservation.flightSeatId,
      ticketOwnerEmail: reservation.ticketOwnerEmail
    });
  }

  // Form navigation
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
