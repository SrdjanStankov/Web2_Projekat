import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { FlightTicketDetails } from '../entities/flight-ticket';
import { FlightService } from '../services/flight.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ticket-history',
  templateUrl: './ticket-history.component.html',
  styleUrls: ['./ticket-history.component.css']
})
export class TicketHistoryComponent implements OnInit {
  flightTickets: FlightTicketDetails[];

  constructor(private userService: UserService, private flightService: FlightService, private router: Router) { }

  ngOnInit(): void {
    const email = this.userService.getLoggedInUserId();
    this.userService.getFlightHistory(email).then((tickets) => {
      this.flightTickets = tickets;
      console.log(tickets);
    });
  }

  onAcceptInvitation(ticket: FlightTicketDetails) {
    this.flightService.acceptInvitation(ticket.id).then(() => {
      this.router.navigate(['/car-reservation'], { queryParams: { address: ticket.flight.to.cityName } });
    })
  }

  onCancelReservation(ticket: FlightTicketDetails) {
    this.flightService.cancelReservation(ticket.id).then(() => {
      window.location.reload();
    })
  }
}
