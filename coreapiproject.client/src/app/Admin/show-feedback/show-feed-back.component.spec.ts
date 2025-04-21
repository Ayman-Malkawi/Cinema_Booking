import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFeedBackComponent } from './show-feed-back.component';

describe('ShowFeedBackComponent', () => {
  let component: ShowFeedBackComponent;
  let fixture: ComponentFixture<ShowFeedBackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowFeedBackComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowFeedBackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
