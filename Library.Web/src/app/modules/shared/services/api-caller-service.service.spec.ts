import { TestBed } from '@angular/core/testing';

import { ApiCallerServiceService } from './api-caller-service.service';

describe('ApiCallerServiceService', () => {
  let service: ApiCallerServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiCallerServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
