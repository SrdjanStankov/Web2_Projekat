import { Component, OnInit, Input } from '@angular/core';
import { FlightSeat } from '../entities/flight-seat';

@Component({
  selector: 'app-flight-seat',
  templateUrl: './flight-seat.component.html',
  styleUrls: ['./flight-seat.component.css']
})
export class FlightSeatComponent implements OnInit {
  @Input() flightSeat: FlightSeat;
  @Input() selectable: boolean;
  selected: boolean;

  constructor() { }

  ngOnInit(): void {
  }

  onSelect() {
    this.selected = !this.selected;
  }
}
