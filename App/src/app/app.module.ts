import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TipoProyectoComponent } from './tipo-proyecto/tipo-proyecto.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ListaProyectosComponent } from './lista-proyectos/lista-proyectos.component';
import { ProyectoComponent } from './proyecto/proyecto.component';
import { ReportesComponent } from './reportes/reportes.component';
import { TiposProyectosComponent } from './Cruds/tipos-proyectos/tipos-proyectos.component';
import { TiposActividadComponent } from './Cruds/tipos-actividad/tipos-actividad.component';
import { TiposTiempoComponent } from './Cruds/tipos-tiempo/tipos-tiempo.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './incerceptors/auth.interceptor';
import { AuthGuardGuard } from './guards/auth-guard.guard';
import { DetalleTipoProyectoComponent } from './detalle-tipo-proyecto/detalle-tipo-proyecto.component';
import { DiasSemanaComponent } from './dias-semana/dias-semana.component';


@NgModule({
  declarations: [
    AppComponent,
    TipoProyectoComponent,
    SidebarComponent,
    DashboardComponent,
    ListaProyectosComponent,
    ProyectoComponent,
    ReportesComponent,
    TiposProyectosComponent,
    TiposActividadComponent,
    TiposTiempoComponent,
    NavbarComponent,
    LoginComponent,
    DetalleTipoProyectoComponent,
    DiasSemanaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    AuthGuardGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
