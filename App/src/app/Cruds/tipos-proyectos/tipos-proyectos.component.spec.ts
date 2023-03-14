import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiposProyectosComponent } from './tipos-proyectos.component';

describe('TiposProyectosComponent', () => {
  let component: TiposProyectosComponent;
  let fixture: ComponentFixture<TiposProyectosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TiposProyectosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TiposProyectosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
