import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPrivateBookComponent } from './add-private-book.component';

describe('AddPrivateBookComponent', () => {
  let component: AddPrivateBookComponent;
  let fixture: ComponentFixture<AddPrivateBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddPrivateBookComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPrivateBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
