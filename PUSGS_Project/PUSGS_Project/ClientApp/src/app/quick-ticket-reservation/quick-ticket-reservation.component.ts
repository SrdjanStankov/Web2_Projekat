import { Component, OnInit } from '@angular/core';
import { AviationService } from '../services/aviation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FlightTicketDetails } from '../entities/flight-ticket';
import { UserService } from '../services/user.service';
import { FlightService } from '../services/flight.service';
import userTypes from '../constants/user-types';

@Component({
  selector: 'app-quick-ticket-reservation',
  templateUrl: './quick-ticket-reservation.component.html',
  styleUrls: ['./quick-ticket-reservation.component.css']
})
export class QuickTicketReservationComponent implements OnInit {
  aviationId: number;
  flightIdFilter: string = "";
  quickTickets: FlightTicketDetails[];

  constructor(private userService: UserService, private aviationService: AviationService, private route: ActivatedRoute, private router: Router, private flightService: FlightService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => { this.aviationId = Number.parseInt(params['id']); })
    this.route.queryParamMap.subscribe(map => {
      this.flightIdFilter = map.get("flight") || "";
    });

    this.aviationService.getAvailableQuickReservations(this.aviationId).then(tickets => {
      this.quickTickets = this.filterTickets(tickets);
      console.log(tickets);
    });
  }

  isAdmin(): boolean {
    return this.userService.getLoggedInUserType() === userTypes.AviationAdmin;
  }

  onReserve(ticket: FlightTicketDetails) {
    const userId = this.userService.getLoggedInUserId();
    this.flightService.makeQuickReservation(userId, ticket.id).then(() => {
      console.log("Made quick reservation");
      this.router.navigateByUrl("");
    });
  }
  onRemove(ticket: FlightTicketDetails) {
    this.flightService.cancelReservation(ticket.id).then(() => {
      window.location.reload();
    });
  }

  onAddClick() {
    this.router.navigateByUrl(`aviation/${this.aviationId}/add-quick-ticket`);
  }

  private filterTickets(tickets: FlightTicketDetails[]): FlightTicketDetails[] {
    if (this.flightIdFilter) {
      const flightId = Number.parseInt(this.flightIdFilter);
      return tickets.filter(t => t.flight.id === flightId);
    }
    return tickets;
  }
}
