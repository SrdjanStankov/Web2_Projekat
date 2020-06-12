import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AviationCompaniesComponent } from './aviation-companies.component';

describe('AviationCompaniesComponent', () => {
  let component: AviationCompaniesComponent;
  let fixture: ComponentFixture<AviationCompaniesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AviationCompaniesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AviationCompaniesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
