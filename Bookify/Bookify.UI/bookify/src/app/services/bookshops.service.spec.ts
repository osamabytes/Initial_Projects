import { TestBed } from '@angular/core/testing';

import { BookshopsService } from './bookshops.service';

describe('BookshopsService', () => {
  let service: BookshopsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookshopsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
