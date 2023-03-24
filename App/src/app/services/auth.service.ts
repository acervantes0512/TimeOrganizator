import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LoginRequest } from '../models/LoginRequest';
import { LoginResponse } from '../models/LoginResponse';
import { TipoProyectoService } from './tipo-proyecto.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public loggedInSubject = new BehaviorSubject<boolean>(false);
  private url = 'https://localhost:44389/api/Auth';
  public User: LoginResponse;  

  constructor(private http: HttpClient) { }

  login(loginData: LoginRequest): Observable<LoginResponse>{
    
    return this.http.post<LoginResponse>(`${this.url}/login`, loginData)
    .pipe(
      map((response: LoginResponse) => {
        localStorage.setItem('token', response.token);
        this.User = response;
        this.loggedInSubject.next(true);
        return response;
      })
    );
  }

  logout() {
    this.loggedInSubject.next(false);
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return this.loggedInSubject.value;
  }

}
