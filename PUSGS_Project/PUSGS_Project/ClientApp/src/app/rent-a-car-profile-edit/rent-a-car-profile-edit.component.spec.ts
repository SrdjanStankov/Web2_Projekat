import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentACarProfileEditComponent } from './rent-a-car-profile-edit.component';

describe('RentACarProfileEditComponent', () => {
  let component: RentACarProfileEditComponent;
  let fixture: ComponentFixture<RentACarProfileEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentACarProfileEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentACarProfileEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
