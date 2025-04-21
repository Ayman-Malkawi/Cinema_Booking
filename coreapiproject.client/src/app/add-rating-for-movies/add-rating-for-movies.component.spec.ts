import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRatingForMoviesComponent } from './add-rating-for-movies.component';

describe('AddRatingForMoviesComponent', () => {
  let component: AddRatingForMoviesComponent;
  let fixture: ComponentFixture<AddRatingForMoviesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddRatingForMoviesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRatingForMoviesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
