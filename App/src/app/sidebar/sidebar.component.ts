import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  isCollapsed = false;
  selectedOption: number = 1;

  toggleParametrizaciones() {
    this.isCollapsed = !this.isCollapsed;
  }

  isActive(option: number){
    return this.selectedOption === option
  }

  setActive(option: number){
    this.selectedOption = option;
  }

}
