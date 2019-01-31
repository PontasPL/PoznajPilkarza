import { TestBed } from '@angular/core/testing';

import { NavbarMainSharedService } from './navbar-main-shared.service';

describe('NavbarMainSharedService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NavbarMainSharedService = TestBed.get(NavbarMainSharedService);
    expect(service).toBeTruthy();
  });
});
