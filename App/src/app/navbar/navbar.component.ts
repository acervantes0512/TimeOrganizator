import { Component, OnInit } from '@angular/core';;
import { LoginResponse } from '../models/LoginResponse';
import { AuthService } from '../services/auth.service';
import { TipoProyectoService } from '../services/tipo-proyecto.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  loggedUser : LoginResponse;
  userLoggedIn : boolean = false;

  constructor(public authService: AuthService, private tiposProyectosService: TipoProyectoService) {
    this.loggedUser = authService.User;
   }

  ngOnInit(): void {    
    this.authService.loggedInSubject.subscribe(
      (isLogged) => 
      {
        this.userLoggedIn = isLogged;
        if(this.userLoggedIn){
          this.loggedUser = this.authService.User;
        }
      }
    );
  }
  
  logOut(){
    this.authService.logout();
    this.tiposProyectosService.resetearTiposProyectos();
  }

}
