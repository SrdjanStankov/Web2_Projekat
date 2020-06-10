import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { FlightTicketDetails } from '../entities/flight-ticket';

@Component({
  selector: 'app-ticket-history',
  templateUrl: './ticket-history.component.html',
  styleUrls: ['./ticket-history.component.css']
})
export class TicketHistoryComponent implements OnInit {
  flightTickets: FlightTicketDetails[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    const email = this.userService.getLoggedInUserId();
    this.userService.getFlightHistory(email).then((tickets) => {
      this.flightTickets = tickets;
      console.log(tickets);
    });
  }

  onAcceptInvitation(ticket: FlightTicketDetails) {
    console.log("accept ticket invitation pressed", ticket);
  }

  onCancelReservation(ticket: FlightTicketDetails) {
    console.log("cancel ticket pressed", ticket);
  }
}
