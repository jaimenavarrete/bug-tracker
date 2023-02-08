import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss'],
})
export class TopbarComponent {
  sidebarOpen: boolean;
  @Output() sidebarOpenClick: EventEmitter<boolean>;

  constructor() {
    this.sidebarOpen = true;
    this.sidebarOpenClick = new EventEmitter<boolean>();
  }

  changeSidebarState() {
    this.sidebarOpen = !this.sidebarOpen;

    this.sidebarOpenClick.emit(this.sidebarOpen);
  }
}
