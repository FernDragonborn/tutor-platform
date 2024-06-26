import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginTutorComponent } from './login-tutor.component';

describe('LoginTutorComponent', () => {
  let component: LoginTutorComponent;
  let fixture: ComponentFixture<LoginTutorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginTutorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoginTutorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
