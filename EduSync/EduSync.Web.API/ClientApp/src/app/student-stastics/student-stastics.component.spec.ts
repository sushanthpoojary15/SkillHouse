import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentStasticsComponent } from './student-stastics.component';

describe('StudentStasticsComponent', () => {
  let component: StudentStasticsComponent;
  let fixture: ComponentFixture<StudentStasticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentStasticsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentStasticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
