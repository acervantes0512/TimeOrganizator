import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LoginRequest } from '../models/LoginRequest';
import { LoginResponse } from '../models/LoginResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn = false;
  private url = 'https://localhost:44389/api/Auth';

  constructor(private http: HttpClient) { }

  login(loginData: LoginRequest): Observable<LoginResponse>{
    
    return this.http.post<LoginResponse>(`${this.url}/login`, loginData)
    .pipe(
      map((response: LoginResponse) => {
        localStorage.setItem('token', response.Token);
        return response;
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

}
