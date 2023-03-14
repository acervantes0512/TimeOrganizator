import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiposActividadComponent } from './tipos-actividad.component';

describe('TiposActividadComponent', () => {
  let component: TiposActividadComponent;
  let fixture: ComponentFixture<TiposActividadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TiposActividadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TiposActividadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
