import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { TipoProyectoService } from '../services/tipo-proyecto.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  submitted: boolean;
  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router, private tiposProyectosService: TipoProyectoService) { }

  ngOnInit(): void {

    this.submitted = false;

    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

  }

  onSubmit(){
    this.submitted = true;
    if(this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe(
        () => {
          this.tiposProyectosService.cargarTiposProyectos();
          this.router.navigate(['/tiposProyectos']);
        },
        error => {
          console.log('Error al iniciar sesión', error);
        }
      );
    }
    else{
      if(this.loginForm.controls.password.invalid){
        console.log("Password invalida");
      }
    }
  }

}
