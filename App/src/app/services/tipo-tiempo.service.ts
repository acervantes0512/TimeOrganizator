import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TipoActividad } from '../models/TipoActividad';
import { TipoTiempo } from '../models/TipoTiempo';

@Injectable({
  providedIn: 'root'
})
export class TipoTiempoService {

  urlTipoActividad = "https://localhost:44389/api/TipoTiempo";
  public listaTipoTiempoSubject = new BehaviorSubject<TipoTiempo[]>([]);

  constructor(private httpClient: HttpClient) { }

  cargarPorIdTipoProyecto(id : number){
    this.httpClient.get<TipoActividad[]>(`${this.urlTipoActividad}/getByProjectType?id=${id}`).subscribe(
      (listaRta) => {
        this.listaTipoTiempoSubject.next(listaRta);
      }
    )
  }
  
}
