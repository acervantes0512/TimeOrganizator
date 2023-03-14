import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TipoProyectoService {

  apiUrl = 'https://localhost:44389/api/TipoProyecto';

  constructor(private http: HttpClient) { }

  // Obtener todos los tipos de proyecto
  getTiposProyecto(): Observable<ITipoProyecto[]> {
    return this.http.get<ITipoProyecto[]>(this.apiUrl);
  }

  // Obtener un tipo de proyecto por ID
  getTipoProyecto(id: number): Observable<ITipoProyecto> {
    return this.http.get<ITipoProyecto>(`${this.apiUrl}/${id}`);
  }

  // Agregar un nuevo tipo de proyecto
  addTipoProyecto(tipoProyecto: ITipoProyecto): Observable<ITipoProyecto> {
    return this.http.post<ITipoProyecto>(this.apiUrl, tipoProyecto);
  }

  // Actualizar un tipo de proyecto existente
  updateTipoProyecto(tipoProyecto: ITipoProyecto): Observable<any> {
    return this.http.put(`${this.apiUrl}/${tipoProyecto.id}`, tipoProyecto);
  }

  // Eliminar un tipo de proyecto
  deleteTipoProyecto(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}