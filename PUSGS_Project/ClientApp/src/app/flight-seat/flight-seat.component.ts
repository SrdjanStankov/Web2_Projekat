import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FlightSeat } from '../entities/flight-seat';

export class FlightSeatSelectedEventArgs {
  constructor(public seat: FlightSeat, public selected: boolean) {
  }
}

@Component({
  selector: 'app-flight-seat',
  templateUrl: './flight-seat.component.html',
  styleUrls: ['./flight-seat.component.css']
})
export class FlightSeatComponent implements OnInit {
  @Input() flightSeat: FlightSeat;
  @Input() selectable: boolean;
  selected: boolean;

  @Output() onSeatSelect: EventEmitter<FlightSeatSelectedEventArgs> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  isDisabled(): boolean {
    return !this.selectable || this.isReserved();
  }

  isReserved(): boolean {
    return !!this.flightSeat.reservedById;
  }

  onSelect() {
    this.selected = !this.selected;

    this.onSeatSelect.emit({ seat: this.flightSeat, selected: this.selected });
  }
}
