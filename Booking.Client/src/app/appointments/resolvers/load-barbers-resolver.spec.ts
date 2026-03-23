import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { loadBarbersResolver } from './load-barbers-resolver';

describe('loadBarbersResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) =>
    TestBed.runInInjectionContext(() => loadBarbersResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
