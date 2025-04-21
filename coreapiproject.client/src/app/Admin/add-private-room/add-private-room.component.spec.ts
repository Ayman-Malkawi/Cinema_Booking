import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPrivateRoomComponent } from './add-private-room.component';

describe('AddPrivateRoomComponent', () => {
  let component: AddPrivateRoomComponent;
  let fixture: ComponentFixture<AddPrivateRoomComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddPrivateRoomComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPrivateRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
