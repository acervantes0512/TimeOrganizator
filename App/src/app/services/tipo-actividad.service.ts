import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
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

  crearNuevoTipoActividad(objTipoActividad: TipoActividad): Observable<TipoActividad> {
    return this.httpClient.post<TipoActividad>(this.url, objTipoActividad)
      .pipe(
        tap((rtaCreacion:TipoActividad) => {
          const listaActual = this.listaTipoActividadSubject.value;
          listaActual.push(rtaCreacion);
          this.listaTipoActividadSubject.next(listaActual);
        })
    )
  }

  eliminarTipoActividad(id:number): Observable<any>{
    return this.httpClient.delete(this.url+"/"+id).pipe(
      tap(
        (rta) => {
          const currentList = this.listaTipoActividadSubject.getValue();
          const newList = currentList.filter(x => x.id !== id);
          this.listaTipoActividadSubject.next(newList);
        }
      )
    )
  }

  actualizarTipoActividad(objTipoActividad: TipoActividad): Observable<TipoActividad>{
    return this.httpClient.put<TipoActividad>(this.url,objTipoActividad).pipe(
      tap(
        () => {
          const currentList = this.listaTipoActividadSubject.getValue();
          const updatedList = currentList.map(x => {
            if(x.id === objTipoActividad.id)
              return objTipoActividad;
            else
              return x;
          });
          this.listaTipoActividadSubject.next(updatedList);
        }        
      )
    )
  }

}
