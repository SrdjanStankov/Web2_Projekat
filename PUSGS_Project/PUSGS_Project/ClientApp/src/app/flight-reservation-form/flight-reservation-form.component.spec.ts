import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightReservationFormComponent } from './flight-reservation-form.component';

describe('FlightReservationFormComponent', () => {
  let component: FlightReservationFormComponent;
  let fixture: ComponentFixture<FlightReservationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightReservationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightReservationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
