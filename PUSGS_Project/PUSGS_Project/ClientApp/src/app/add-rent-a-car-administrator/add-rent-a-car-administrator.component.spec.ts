import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRentACarAdministratorComponent } from './add-rent-a-car-administrator.component';

describe('AddRentACarAdministratorComponent', () => {
  let component: AddRentACarAdministratorComponent;
  let fixture: ComponentFixture<AddRentACarAdministratorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddRentACarAdministratorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRentACarAdministratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
