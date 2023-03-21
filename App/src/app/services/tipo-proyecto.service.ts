import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoProyecto } from '../models/TipoProyecto';

@Injectable({
  providedIn: 'root'
})
export class TipoProyectoService {

  apiUrl = 'https://localhost:44389/api/TipoProyecto';

  constructor(private http: HttpClient) { }

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
    return this.http.post<TipoProyecto>(this.apiUrl, tipoProyecto);
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