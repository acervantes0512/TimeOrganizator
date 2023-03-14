import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TiposActividadComponent } from './Cruds/tipos-actividad/tipos-actividad.component';
import { TiposProyectosComponent } from './Cruds/tipos-proyectos/tipos-proyectos.component';
import { TiposTiempoComponent } from './Cruds/tipos-tiempo/tipos-tiempo.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ListaProyectosComponent } from './lista-proyectos/lista-proyectos.component';
import { LoginComponent } from './login/login.component';
import { ProyectoComponent } from './proyecto/proyecto.component';
import { ReportesComponent } from './reportes/reportes.component';

const routes: Routes = [
  { path: '', redirectTo:'/dashboard', pathMatch:'full'},
  { path: 'dashboard', component: DashboardComponent},
  { path: 'proyectos', component: ListaProyectosComponent},
  { path: 'proyecto', component: ProyectoComponent},
  { path: 'reportes', component: ReportesComponent},
  { path: 'tiposProyectos', component: TiposProyectosComponent},
  { path: 'tiposActividad', component: TiposActividadComponent},
  { path: 'tiposTiempo', component: TiposTiempoComponent},
  { path: 'login', component: LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
