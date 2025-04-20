import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateRoomsComponent } from './private-rooms.component';

describe('PrivateRoomsComponent', () => {
  let component: PrivateRoomsComponent;
  let fixture: ComponentFixture<PrivateRoomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PrivateRoomsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrivateRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
