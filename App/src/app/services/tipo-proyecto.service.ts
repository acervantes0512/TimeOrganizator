import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { TipoProyecto } from '../models/TipoProyecto';
import { AuthService } from './auth.service';
import { tap } from 'rxjs/internal/operators/tap';

@Injectable({
  providedIn: 'root'
})
export class TipoProyectoService {

  apiUrl = 'https://localhost:44389/api/TipoProyecto';
  public tiposProyectosSubject = new BehaviorSubject<TipoProyecto[]>([]);  

  constructor(private http: HttpClient, private authService: AuthService) { 
    this.getTiposProyecto().subscribe((tiposProyecto) => {
      this.tiposProyectosSubject.next(tiposProyecto);
    });
  }

  // Obtener todos los tipos de proyecto
  getTiposProyecto(): Observable<TipoProyecto[]> {    
    return this.http.get<TipoProyecto[]>(this.apiUrl);
  }

  // Obtener un tipo de proyecto por ID
  getTipoProyecto(id: number): Observable<TipoProyecto> {
    return this.http.get<TipoProyecto>(`${this.apiUrl}/${id}`);
  }

  // Agregar un nuevo tipo de proyecto
  addTipoProyecto(tipoProyecto: TipoProyecto): Observable<TipoProyecto> {
    tipoProyecto.estadoId = 2;
    tipoProyecto.usuarioId = this.authService.User.id;
    return this.http.post<TipoProyecto>(this.apiUrl, tipoProyecto)
      .pipe(
        tap((response) => {
          const tiposProyecto = this.tiposProyectosSubject.getValue();
          tiposProyecto.push(response);
          this.tiposProyectosSubject.next(tiposProyecto);
        })
      );
  }

  // Actualizar un tipo de proyecto existente
  updateTipoProyecto(tipoProyecto: TipoProyecto): Observable<any> {
    return this.http.put(`${this.apiUrl}/${tipoProyecto.id}`, tipoProyecto);
  }

  // Eliminar un tipo de proyecto
  deleteTipoProyecto(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}