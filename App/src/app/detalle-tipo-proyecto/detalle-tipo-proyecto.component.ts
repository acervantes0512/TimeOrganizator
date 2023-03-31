import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TipoActividad } from '../models/TipoActividad';
import { TipoActividadService } from '../services/tipo-actividad.service';
declare var window : any;

@Component({
  selector: 'app-detalle-tipo-proyecto',
  templateUrl: './detalle-tipo-proyecto.component.html',
  styleUrls: ['./detalle-tipo-proyecto.component.scss']
})
export class DetalleTipoProyectoComponent implements OnInit {

  idTipoProyecto: any;
  modalTipoActividad : any;
  formTipoActividad : FormGroup;
  editModeTipoActividad : boolean;
  tiposActividades : TipoActividad[];  

  constructor(private activatedRoute: ActivatedRoute, private tipoActividadService: TipoActividadService) { }

  ngOnInit(): void {
      this.activatedRoute.params.subscribe(params => {
      this.idTipoProyecto = params['id'];
      this.tipoActividadService.cargarTiposActividadesPorTipoProyecto(this.idTipoProyecto);
    });
    

    this.tipoActividadService.listaTipoActividadSubject.subscribe(
      (tiposActividades) => {
        this.tiposActividades = tiposActividades;
      }
    );

  };

  openModalTipoActividad(){
    this.modalTipoActividad.show();
    this.modalTipoActividad = new window.bootstrap.Modal(
      document.getElementById('modalTipoActividades')
    );
  }

  submitModalTipoActividad(){

  }

  closeFormModalTipoActividad(){
    this.modalTipoActividad.hide();
  }

  editarTipoActivividad(tipoActividad : TipoActividad){

  }

  eliminarTipoActividad(id:number){

  }
}
