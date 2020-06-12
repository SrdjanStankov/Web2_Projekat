import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { FlightTicketDetails, FlightTicket } from '../entities/flight-ticket';
import { FlightService } from '../services/flight.service';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-ticket-history',
  templateUrl: './ticket-history.component.html',
  styleUrls: ['./ticket-history.component.css']
})
export class TicketHistoryComponent implements OnInit {
  flightTickets: FlightTicketDetails[];
  rating = new FormControl(null, Validators.required);

  constructor(private userService: UserService, private flightService: FlightService, private router: Router, private modalService: NgbModal) { }

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

  onRate(rateModal, ticket: FlightTicket) {
    this.modalService.open(rateModal, { ariaLabelledBy: 'modal-add-rating' }).result.then(() => {
      const newRating = Number.parseFloat(this.rating.value);
      this.flightService.rate(ticket.id, newRating).then(() => {
        window.location.reload();
      });
    });
  }
}
