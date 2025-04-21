import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAllRoomsComponent } from './show-all-rooms.component';

describe('ShowAllRoomsComponent', () => {
  let component: ShowAllRoomsComponent;
  let fixture: ComponentFixture<ShowAllRoomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowAllRoomsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAllRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
