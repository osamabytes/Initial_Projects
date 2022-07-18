import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCustomerDropdownComponent } from './admin-customer-dropdown.component';

describe('AdminCustomerDropdownComponent', () => {
  let component: AdminCustomerDropdownComponent;
  let fixture: ComponentFixture<AdminCustomerDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminCustomerDropdownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCustomerDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
