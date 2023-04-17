import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  tipoActividadSeleccionada: TipoActividad;
  tipoTiempoSeleccionado: TipoTiempo;
  editModeTipoTiempo : boolean;
  formTipoTiempo : FormGroup;

  constructor(private formBuilder: FormBuilder, private activatedRoute: ActivatedRoute, private tipoActividadService: TipoActividadService, private tipoTiempoService: TipoTiempoService) { }

  ngOnInit(): void {
      this.activatedRoute.params.subscribe(params => {
      this.idTipoProyecto = params['id'];
      this.tipoActividadService.cargarTiposActividadesPorTipoProyecto(this.idTipoProyecto);
      this.tipoTiempoService.cargarPorIdTipoProyecto(this.idTipoProyecto);
    });

    this.editModeTipoActividad = false;
    this.editModeTipoTiempo = false;

    this.formTipoActividad = this.formBuilder.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required]
    });

    this.formTipoTiempo = this.formBuilder.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required]
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
    if(!this.editModeTipoActividad)
      this.createTipoActividad();
    else
      this.guardarTipoActividadEditada();
  }

  submitModalTipoTiempo(){
    if(!this.editModeTipoTiempo)
      this.crearTipoTiempo();
    else
      this.guardarTipoTiempoEditado();
  }

  closeFormModalTipoActividad(){
    this.modalTipoActividad.hide();
  }

  closeFormModalTipoTiempo(){
    this.modalTipoActividad.hide();
  }

  createTipoActividad(){
    var tipoAct: TipoActividad = this.formTipoActividad.value;
    tipoAct.estadoId = 2;    
    tipoAct.tipoProyectoId = this.idTipoProyecto;

    this.tipoActividadService.crearNuevoTipoActividad(tipoAct).subscribe(
      (rta) => {
        console.log("Creación exitosa tipo actividad");                        
      },
      (error) => {
        console.log("Error creando tipo actividad");        
      }
    );

    this.formTipoActividad.reset();
    this.modalTipoActividad.hide();
  }

  guardarTipoActividadEditada(){
    
    var updatedRecord : TipoActividad = this.formTipoActividad.value;
    this.tipoActividadSeleccionada.nombre = updatedRecord.nombre;
    this.tipoActividadSeleccionada.descripcion = updatedRecord.descripcion;
    this.tipoActividadService.actualizarTipoActividad(this.tipoActividadSeleccionada).subscribe(
      () => {
        this.formTipoActividad.reset;
        this.modalTipoActividad.hide();
        this.editModeTipoActividad = false;
      },
      (error) => {
        console.log("Error actualizando Tipo Actividad:"+ error);
        
      }
    )
    this.formTipoActividad.reset();
    this.editModeTipoActividad = false;
  }


  editarTipoActivividad(tipoActividad : TipoActividad){
    this.tipoActividadSeleccionada = tipoActividad;
    this.editModeTipoActividad = true;
    this.modalTipoActividad.show();
    this.formTipoActividad.setValue({
      nombre: tipoActividad.nombre,
      descripcion: tipoActividad.descripcion
    })
  }

  eliminarTipoActividad(id:number){
    this.tipoActividadService.eliminarTipoActividad(id).subscribe(
      () => {
        console.log("Eliminación Exitosa!");        
      },
      (error) => {
        console.log("Error al eliminar registro");        
      }
    )
  }

  editarTipoTiempo(tipoTiempo : TipoTiempo){
    this.tipoTiempoSeleccionado = tipoTiempo;
    this.editModeTipoTiempo = true;
    this.formTipoTiempo.setValue({
      nombre: tipoTiempo.nombre,
      descripcion: tipoTiempo.descripcion
    });
    this.modalTipoTiempo.show();
  }

  eliminarTipoTiempo(id:number){
    this.tipoTiempoService.eliminarTipoTiempo(id).subscribe(
      () => {
        console.log("Eliminación exitosa!");        
      },
      (error) => {
        console.log("Error Eliminación!");       
      }
    )
  }

  guardarTipoTiempoEditado(){
    var tipoTiempo: TipoTiempo = this.formTipoTiempo.value;
    this.tipoTiempoSeleccionado.nombre = tipoTiempo.nombre;
    this.tipoTiempoSeleccionado.descripcion = tipoTiempo.descripcion;

    this.tipoTiempoService.editarTipoTiempo(this.tipoTiempoSeleccionado).subscribe(
      () => {
        console.log("Actualización exitosa!");        
      },
      (error) => {
        console.log("Error actualizando!");
        
      }
    )
    this.formTipoTiempo.reset();
    this.modalTipoTiempo.hide();
  }

  crearTipoTiempo(){
    var tipoTiempo: TipoTiempo = this.formTipoTiempo.value;
    tipoTiempo.tipoProyectoId = this.idTipoProyecto;
    this.tipoTiempoService.agregarNuevoTipoTiempo(tipoTiempo).subscribe(
      () => {
        console.log("Creación Exitosa!");        
      },
      () => {
        console.log("Error creando!");        
      }
    )
    this.formTipoTiempo.reset();
    this.modalTipoTiempo.hide();
  }
}
