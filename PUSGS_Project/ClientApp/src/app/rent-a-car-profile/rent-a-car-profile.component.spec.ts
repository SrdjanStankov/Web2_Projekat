import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentACarProfileComponent } from './rent-a-car-profile.component';

describe('RentACarProfileComponent', () => {
  let component: RentACarProfileComponent;
  let fixture: ComponentFixture<RentACarProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentACarProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentACarProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
