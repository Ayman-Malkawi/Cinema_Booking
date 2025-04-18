import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingForSeatComponent } from './booking-for-seat.component';

describe('BookingForSeatComponent', () => {
  let component: BookingForSeatComponent;
  let fixture: ComponentFixture<BookingForSeatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BookingForSeatComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookingForSeatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
