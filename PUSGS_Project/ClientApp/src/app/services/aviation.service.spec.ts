import { TestBed } from '@angular/core/testing';

import { AviationService } from './aviation.service';

describe('AviationService', () => {
  let service: AviationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AviationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
