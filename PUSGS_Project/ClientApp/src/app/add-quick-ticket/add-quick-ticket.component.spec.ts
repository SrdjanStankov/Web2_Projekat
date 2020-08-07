import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddQuickTicketComponent } from './add-quick-ticket.component';

describe('AddQuickTicketComponent', () => {
  let component: AddQuickTicketComponent;
  let fixture: ComponentFixture<AddQuickTicketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddQuickTicketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddQuickTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
