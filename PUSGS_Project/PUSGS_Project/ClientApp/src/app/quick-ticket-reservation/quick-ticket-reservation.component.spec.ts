import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickTicketReservationComponent } from './quick-ticket-reservation.component';

describe('QuickTicketReservationComponent', () => {
  let component: QuickTicketReservationComponent;
  let fixture: ComponentFixture<QuickTicketReservationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickTicketReservationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickTicketReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
