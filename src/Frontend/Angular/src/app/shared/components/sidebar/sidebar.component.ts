import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { ProjectList } from 'src/app/pages/projects/interfaces/project-list.interface';
import { ProjectsService } from 'src/app/pages/projects/services/projects.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
  projectsList!: ProjectList[];
  @Input() sidebarOpen!: boolean;

  constructor(private projectsService: ProjectsService) {}

  ngOnInit(): void {
    this.projectsService.projectsListAction$.subscribe(
      (res) => (this.projectsList = res.data)
    );

    this.projectsService.projectsListSubjectUpdate();
  }

  changeSidebarState() {
    this.sidebarOpen = !this.sidebarOpen;
  }
}
