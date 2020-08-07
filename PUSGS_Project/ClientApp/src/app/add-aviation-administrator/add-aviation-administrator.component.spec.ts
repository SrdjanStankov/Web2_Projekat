import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAviationAdministratorComponent } from './add-aviation-administrator.component';

describe('AddAviationAdministratorComponent', () => {
  let component: AddAviationAdministratorComponent;
  let fixture: ComponentFixture<AddAviationAdministratorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddAviationAdministratorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAviationAdministratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
