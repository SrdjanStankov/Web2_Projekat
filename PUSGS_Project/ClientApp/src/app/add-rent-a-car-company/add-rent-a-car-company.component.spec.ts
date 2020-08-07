import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRentACarCompanyComponent } from './add-rent-a-car-company.component';

describe('AddRentACarCompanyComponent', () => {
  let component: AddRentACarCompanyComponent;
  let fixture: ComponentFixture<AddRentACarCompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddRentACarCompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRentACarCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
