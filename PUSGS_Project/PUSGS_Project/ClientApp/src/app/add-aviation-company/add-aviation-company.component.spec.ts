import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAviationCompanyComponent } from './add-aviation-company.component';

describe('AddAviationCompanyComponent', () => {
  let component: AddAviationCompanyComponent;
  let fixture: ComponentFixture<AddAviationCompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddAviationCompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAviationCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
