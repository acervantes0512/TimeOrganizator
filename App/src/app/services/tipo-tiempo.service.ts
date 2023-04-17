import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { TipoActividad } from '../models/TipoActividad';
import { TipoTiempo } from '../models/TipoTiempo';

@Injectable({
  providedIn: 'root'
})
export class TipoTiempoService {

  urlTipoTiempo = "https://localhost:44389/api/TipoTiempo";
  public listaTipoTiempoSubject = new BehaviorSubject<TipoTiempo[]>([]);

  constructor(private httpClient: HttpClient) { }

  cargarPorIdTipoProyecto(id : number){
    this.httpClient.get<TipoActividad[]>(`${this.urlTipoTiempo}/getByProjectType?id=${id}`).subscribe(
      (listaRta) => {
        this.listaTipoTiempoSubject.next(listaRta);
      }
    )
  }

  agregarNuevoTipoTiempo(objTipoTiempo: TipoTiempo): Observable<TipoTiempo>{
    return this.httpClient.post<TipoTiempo>(this.urlTipoTiempo, objTipoTiempo).pipe(
      tap(
        (rta) => {
          const currentList = this.listaTipoTiempoSubject.getValue();
          currentList.push(rta);
          this.listaTipoTiempoSubject.next(currentList);
        }
      )
    )
  }
  

  editarTipoTiempo(objTipoTiempo: TipoTiempo): Observable<TipoTiempo>{
    return this.httpClient.put<TipoTiempo>(this.urlTipoTiempo, objTipoTiempo).pipe(
      tap(
        () => {
          const currentList = this.listaTipoTiempoSubject.getValue();
          const updatedList = currentList.map(x => {
            if(x.id === objTipoTiempo.id)
              return objTipoTiempo;
            else
              return x;
          });
          this.listaTipoTiempoSubject.next(updatedList);
        }
      )
    )
  }

  eliminarTipoTiempo(id: number): Observable<any>{
    return this.httpClient.delete(this.urlTipoTiempo+"/"+id).pipe(
      tap(
        () => {
          const currentList = this.listaTipoTiempoSubject.getValue();
          const updatedList = currentList.filter(x => x.id !== id);
          this.listaTipoTiempoSubject.next(updatedList);
        }
      )
    )
  }
  
}
