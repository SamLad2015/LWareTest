import { TestBed, inject } from '@angular/core/testing';

import { RoverDataService } from './rover-data.service';

describe('RoverDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RoverDataService]
    });
  });

  it('should be created', inject([RoverDataService], (service: RoverDataService) => {
    expect(service).toBeTruthy();
  }));
});
