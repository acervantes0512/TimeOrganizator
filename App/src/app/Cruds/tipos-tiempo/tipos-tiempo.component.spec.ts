import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiposTiempoComponent } from './tipos-tiempo.component';

describe('TiposTiempoComponent', () => {
  let component: TiposTiempoComponent;
  let fixture: ComponentFixture<TiposTiempoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TiposTiempoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TiposTiempoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
