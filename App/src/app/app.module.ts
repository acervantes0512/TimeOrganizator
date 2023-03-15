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
import { HttpClientModule } from '@angular/common/http';


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
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
