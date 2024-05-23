import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedComponent } from './tutors.component';

describe('TutorsComponent', () => {
  let component: FeedComponent;
  let fixture: ComponentFixture<FeedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FeedComponent]
    });
    fixture = TestBed.createComponent(FeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
