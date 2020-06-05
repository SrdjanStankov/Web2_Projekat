import { Component, OnInit, Input } from '@angular/core';
import { FlightSeat } from '../entities/flight-seat';

@Component({
  selector: 'app-flight-seats',
  templateUrl: './flight-seats.component.html',
  styleUrls: ['./flight-seats.component.css']
})
export class FlightSeatsComponent implements OnInit {
  @Input() flightSeats: FlightSeat[] = [];
  @Input() selectable: boolean;
  @Input() maxSeatsPerRow = 4;

  constructor() { }

  ngOnInit(): void {
    const mockedSeats = this.createMockSeats();
    const sortedSeats = mockedSeats.sort((a, b) => a.seatNumber - b.seatNumber);
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

  private createMockSeats(numSeats = 20): FlightSeat[] {
    const seats = [];
    for (let i = 0; i < numSeats; ++i) {
      const seat = new FlightSeat();
      seat.seatNumber = i;
      seats.push(seat);
    }
    return seats;
  }
}
