import { TestBed } from '@angular/core/testing';

import { TipoTiempoService } from './tipo-tiempo.service';

describe('TipoTiempoService', () => {
  let service: TipoTiempoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoTiempoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
