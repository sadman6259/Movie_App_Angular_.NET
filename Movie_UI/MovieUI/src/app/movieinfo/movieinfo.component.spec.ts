import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieinfoComponent } from './movieinfo.component';

describe('FreelancerinfoComponent', () => {
  let component: MovieinfoComponent;
  let fixture: ComponentFixture<MovieinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MovieinfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
