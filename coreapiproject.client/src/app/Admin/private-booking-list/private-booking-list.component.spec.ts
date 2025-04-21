import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateBookingListComponent } from './private-booking-list.component';

describe('PrivateBookingListComponent', () => {
  let component: PrivateBookingListComponent;
  let fixture: ComponentFixture<PrivateBookingListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PrivateBookingListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrivateBookingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
