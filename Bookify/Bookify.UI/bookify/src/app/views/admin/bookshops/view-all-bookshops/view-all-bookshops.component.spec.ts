import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllBookshopsComponent } from './view-all-bookshops.component';

describe('ViewAllBookshopsComponent', () => {
  let component: ViewAllBookshopsComponent;
  let fixture: ComponentFixture<ViewAllBookshopsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAllBookshopsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewAllBookshopsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
