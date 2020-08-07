import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterServicesComponent } from './register-services.component';

describe('RegisterServicesComponent', () => {
  let component: RegisterServicesComponent;
  let fixture: ComponentFixture<RegisterServicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterServicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
