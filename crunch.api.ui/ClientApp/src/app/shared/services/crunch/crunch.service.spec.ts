import { TestBed } from '@angular/core/testing';

import { CrunchService } from './crunch.service';

describe('CrunchService', () => {
  let service: CrunchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CrunchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
