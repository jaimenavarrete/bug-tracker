import { Component, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent {
  @Input() sidebarOpen!: boolean;

  constructor() {}

  changeSidebarState() {
    this.sidebarOpen = !this.sidebarOpen;
  }
}
