import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AviationProfileComponent } from './aviation-profile.component';

describe('AviationProfileComponent', () => {
  let component: AviationProfileComponent;
  let fixture: ComponentFixture<AviationProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AviationProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AviationProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
