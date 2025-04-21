import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageRoomAvailabilityComponent } from './manage-room-availability.component';

describe('ManageRoomAvailabilityComponent', () => {
  let component: ManageRoomAvailabilityComponent;
  let fixture: ComponentFixture<ManageRoomAvailabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ManageRoomAvailabilityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageRoomAvailabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
