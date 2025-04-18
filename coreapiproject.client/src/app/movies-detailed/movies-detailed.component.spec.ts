import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesDetailedComponent } from './movies-detailed.component';

describe('MoviesDetailedComponent', () => {
  let component: MoviesDetailedComponent;
  let fixture: ComponentFixture<MoviesDetailedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MoviesDetailedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MoviesDetailedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
