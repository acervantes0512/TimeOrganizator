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

  formModal: any;
  formCrear: FormGroup;
  tiposProyectos: TipoProyecto[];
  

  constructor(private formBuilder: FormBuilder, private tipoProyectoService: TipoProyectoService) { }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('nuevoModal')
    );

    this.formCrear = this.formBuilder.group({
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
    this.formModal.show();
  }

  submitModal(){
    debugger
    this.tipoProyectoService.addTipoProyecto(this.formCrear.value).subscribe(
      () => {        
        console.log("Creación exitosa!!");
      },
      error => {
        console.log("Error en la creación!!");
        
      }
    )

    this.formModal.hide();
  }

  closeFormModal(){
    this.formModal.hide();
  }

}
