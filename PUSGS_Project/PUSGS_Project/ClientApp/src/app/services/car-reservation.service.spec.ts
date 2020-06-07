import { TestBed } from '@angular/core/testing';

import { CarReservationService } from './car-reservation.service';

describe('CarReservationService', () => {
  let service: CarReservationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarReservationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
