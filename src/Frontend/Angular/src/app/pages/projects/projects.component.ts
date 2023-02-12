import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { ProjectList } from './interfaces/project-list.interface';
import { ProjectsService } from './services/projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
})
export class ProjectsComponent implements OnInit {
  projectsList!: ProjectList[];

  constructor(private projectsService: ProjectsService) {}

  ngOnInit(): void {
    this.projectsService.projectsListAction$.subscribe(
      (res) => (this.projectsList = res.data)
    );
  }
}
