import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn = false;
  private token : string;

  constructor(private http: HttpClient) { }

  login(loginData: ILogin){
    
  }

}
