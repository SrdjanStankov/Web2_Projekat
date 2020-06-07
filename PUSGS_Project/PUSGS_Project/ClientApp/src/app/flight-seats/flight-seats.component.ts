import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FlightSeat } from '../entities/flight-seat';
import { FlightSeatSelectedEventArgs } from '../flight-seat/flight-seat.component';

@Component({
  selector: 'app-flight-seats',
  templateUrl: './flight-seats.component.html',
  styleUrls: ['./flight-seats.component.css']
})
export class FlightSeatsComponent implements OnInit {
  @Input() flightSeats: FlightSeat[] = [];
  @Input() selectable: boolean;
  @Input() maxSeatsPerRow = 4;
  @Input() hideLegend: boolean;

  @Output() onSeatSelectedChange: EventEmitter<FlightSeatSelectedEventArgs> = new EventEmitter();

  constructor() { }

  onSeatSelect(args: FlightSeatSelectedEventArgs) {
    this.onSeatSelectedChange.emit(args);
  }

  ngOnInit(): void {
    if (this.flightSeats.length === 0)
      return;

    const sortedSeats = this.flightSeats.sort((a, b) => a.seatNumber - b.seatNumber);
    this.flightSeats = this.fillGap(sortedSeats);
  }

  private fillGap(sortedSeats: FlightSeat[] = []) {
    const seats = [];
    const lastSeat = sortedSeats[sortedSeats.length - 1];

    for (let i = 0, currSeatNumber = 0; i <= lastSeat.seatNumber; ++i) {
      const currSeat = sortedSeats[currSeatNumber];
      if (currSeat.seatNumber !== i) {
        seats.push({});
        continue;
      }
      seats.push(currSeat)
      ++currSeatNumber;
    }

    return seats;
  }
}
