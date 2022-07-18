import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminBookshopDropdownComponent } from './admin-bookshop-dropdown.component';

describe('AdminBookshopDropdownComponent', () => {
  let component: AdminBookshopDropdownComponent;
  let fixture: ComponentFixture<AdminBookshopDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminBookshopDropdownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminBookshopDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
