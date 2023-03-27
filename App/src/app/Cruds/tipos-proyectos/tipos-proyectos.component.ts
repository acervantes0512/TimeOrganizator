import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TipoProyecto } from 'src/app/models/TipoProyecto';
import { TipoProyectoService } from 'src/app/services/tipo-proyecto.service';
declare var window: any;

@Component({
  selector: 'app-tipos-proyectos',
  templateUrl: './tipos-proyectos.component.html',
  styleUrls: ['./tipos-proyectos.component.scss']
})
export class TiposProyectosComponent implements OnInit {

  objModal: any;
  formTipoProyecto: FormGroup;
  tiposProyectos: TipoProyecto[];
  selectedTipoProyecto : TipoProyecto;
  editMode: boolean = false;
  

  constructor(private formBuilder: FormBuilder, private tipoProyectoService: TipoProyectoService) { }

  ngOnInit(): void {
    this.objModal = new window.bootstrap.Modal(
      document.getElementById('nuevoModal')
    );    

    this.formTipoProyecto = this.formBuilder.group({
      nombre: ['',Validators.required],
      descripcion: ['',Validators.required]
    });

    this.tipoProyectoService.tiposProyectosSubject.subscribe(
      (tiposProyectosU) => {
        this.tiposProyectos = tiposProyectosU;
      }
    )

  }
  openFormModal(){
    this.editMode = false;
    this.objModal.show();
  }

  submitModal(){
    if(this.editMode)
      this.saveEditRecord();
    else
      this.createRecord();
  }

  createRecord(){
    this.tipoProyectoService.addTipoProyecto(this.formTipoProyecto.value).subscribe(
      () => {        
        console.log("Creación exitosa!!");
      },
      error => {
        console.log("Error en la creación!!");
        
      }
    );
    this.formTipoProyecto.reset();      
    this.objModal.hide();
  }

  saveEditRecord(){
    var updatedObject:TipoProyecto = this.formTipoProyecto.value;
    this.selectedTipoProyecto.descripcion = updatedObject.descripcion;
    this.selectedTipoProyecto.nombre = updatedObject.nombre;

    this.tipoProyectoService.updateTipoProyecto(this.selectedTipoProyecto).subscribe(
      () => {
        console.log("Actualización Exitosa!!");        
      },
      error => {
        console.log("Error Actualizando!!");
        
      }
    );
    this.formTipoProyecto.reset();
    this.objModal.hide();
  }

  closeFormModal(){    
    this.formTipoProyecto.reset();
    this.objModal.hide();
  }

  editRecord(selectedTipoProy: TipoProyecto){
    this.selectedTipoProyecto = selectedTipoProy;
    this.editMode = true;
    this.formTipoProyecto.setValue({
      nombre: selectedTipoProy.nombre,
      descripcion: selectedTipoProy.descripcion      
    });
    this.objModal.show();
  }

  deleteRecord(id:number){
    this.tipoProyectoService.deleteTipoProyecto(id).subscribe(
      () => {
        console.log("Eliminación Exitosa!");        
      },
      error => {
        console.log("Error al eliminar!!");
        
      }
    )
  }


}
