import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminBookDropdownComponent } from './admin-book-dropdown.component';

describe('AdminBookDropdownComponent', () => {
  let component: AdminBookDropdownComponent;
  let fixture: ComponentFixture<AdminBookDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminBookDropdownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminBookDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
