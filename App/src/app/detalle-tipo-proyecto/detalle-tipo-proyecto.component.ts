import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TipoActividad } from '../models/TipoActividad';
import { TipoTiempo } from '../models/TipoTiempo';
import { TipoActividadService } from '../services/tipo-actividad.service';
import { TipoTiempoService } from '../services/tipo-tiempo.service';
declare var window : any;

@Component({
  selector: 'app-detalle-tipo-proyecto',
  templateUrl: './detalle-tipo-proyecto.component.html',
  styleUrls: ['./detalle-tipo-proyecto.component.scss']
})
export class DetalleTipoProyectoComponent implements OnInit {

  idTipoProyecto: any;
  modalTipoActividad : any;
  modalTipoTiempo : any;
  formTipoActividad : FormGroup;
  editModeTipoActividad : boolean;
  tiposActividades : TipoActividad[];  
  tiposTiempo : TipoTiempo[];  

  constructor(private activatedRoute: ActivatedRoute, private tipoActividadService: TipoActividadService, private tipoTiempoService: TipoTiempoService) { }

  ngOnInit(): void {
      this.activatedRoute.params.subscribe(params => {
      this.idTipoProyecto = params['id'];
      this.tipoActividadService.cargarTiposActividadesPorTipoProyecto(this.idTipoProyecto);
      this.tipoTiempoService.cargarPorIdTipoProyecto(this.idTipoProyecto);
    });
    

    this.tipoActividadService.listaTipoActividadSubject.subscribe(
      (tiposActividades) => {
        this.tiposActividades = tiposActividades;
      }
    );

    this.tipoTiempoService.listaTipoTiempoSubject.subscribe(
      (rtaTiposTiempo) => {
        this.tiposTiempo = rtaTiposTiempo;
      }
    );

    this.modalTipoActividad = new window.bootstrap.Modal(
      document.getElementById('modalTipoActividades')
    );

    this.modalTipoTiempo = new window.bootstrap.Modal(
      document.getElementById('modalTipoTiempo')
    )

  };

  openModalTipoActividad(){
    this.modalTipoActividad.show();
  }

  openModalTipoTiempo(){
    this.modalTipoTiempo.show();
  }

  submitModalTipoActividad(){

  }

  submitModalTipoTiempo(){

  }

  closeFormModalTipoActividad(){
    this.modalTipoActividad.hide();
  }

  closeFormModalTipoTiempo(){
    this.modalTipoActividad.hide();
  }

  editarTipoActivividad(tipoActividad : TipoActividad){

  }

  eliminarTipoActividad(id:number){

  }

  editarTipoTiempo(tipoTiempo : TipoTiempo){

  }

  eliminarTipoTiempo(id:number){

  }
}
