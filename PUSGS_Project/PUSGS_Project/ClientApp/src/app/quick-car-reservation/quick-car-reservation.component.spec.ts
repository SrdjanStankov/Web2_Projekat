import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickCarReservationComponent } from './quick-car-reservation.component';

describe('QuickCarReservationComponent', () => {
  let component: QuickCarReservationComponent;
  let fixture: ComponentFixture<QuickCarReservationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickCarReservationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickCarReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
