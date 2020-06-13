import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-accept-invitation',
  templateUrl: './accept-invitation.component.html',
  styleUrls: ['./accept-invitation.component.css']
})
export class AcceptInvitationComponent implements OnInit {
  result: string;
  ticketId: string;

  constructor(private flightService: FlightService, route: ActivatedRoute, private router: Router) {
    route.params.subscribe(params => { this.ticketId = params['id']; });
    this.result = "Waiting for response...";
  }

  ngOnInit(): void {
    const id = Number.parseInt(this.ticketId);
    this.flightService.acceptInvitation(id).then(() => {
      this.result = "Accepted";
      setTimeout(() => {
        this.router.navigateByUrl("");
      }, 1500);
    }, err => {
      this.result = JSON.stringify(err);
    });
  }
}
