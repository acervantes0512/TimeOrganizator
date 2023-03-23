import { Component, OnInit } from '@angular/core';
declare var window: any;

@Component({
  selector: 'app-tipos-tiempo',
  templateUrl: './tipos-tiempo.component.html',
  styleUrls: ['./tipos-tiempo.component.scss']
})
export class TiposTiempoComponent implements OnInit {

  formModal: any;
  constructor() { }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('myModal')
    );
  }

  openFormModal(){
    this.formModal.show();
  }

  submitModal(){
    this.formModal.hide();
  }

}
