import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { TipoActividad } from '../models/TipoActividad';

@Injectable({
  providedIn: 'root'
})
export class TipoActividadService {
  
  url = "https://localhost:44389/api/TipoActividad";
  public listaTipoActividadSubject = new BehaviorSubject<TipoActividad[]>([]);

  constructor(private httpClient: HttpClient) {     
  }

  cargarTiposActividadesPorTipoProyecto(id : number) {
    this.httpClient.get<TipoActividad[]>(`${this.url}/GetByProjectType?id=${id}`).subscribe(
      (listaRta) => {
        this.listaTipoActividadSubject.next(listaRta);
      }
    )
  }

}
