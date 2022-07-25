import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatebookshopComponent } from './createbookshop.component';

describe('CreatebookshopComponent', () => {
  let component: CreatebookshopComponent;
  let fixture: ComponentFixture<CreatebookshopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatebookshopComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatebookshopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
