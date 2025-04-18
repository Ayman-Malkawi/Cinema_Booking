import { TestBed } from '@angular/core/testing';

import { AUrlService } from './a-url.service';

describe('AUrlService', () => {
  let service: AUrlService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AUrlService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
