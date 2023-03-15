import { Component, OnInit } from '@angular/core';
import { LoginResponse } from '../models/LoginResponse';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  loggedUser : LoginResponse;
  constructor(private authService: AuthService) {
    this.loggedUser = authService.User;
   }

  ngOnInit(): void {
  }

}
