import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookshopsTableComponent } from './bookshops-table.component';

describe('BookshopsTableComponent', () => {
  let component: BookshopsTableComponent;
  let fixture: ComponentFixture<BookshopsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookshopsTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookshopsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
