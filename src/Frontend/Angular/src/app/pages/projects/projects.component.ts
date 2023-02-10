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
    this.updateProjectsList();
  }

  updateProjectsList(): void {
    this.getProjects();
  }

  private getProjects(): void {
    this.projectsService
      .getProjects()
      .pipe(tap((res) => (this.projectsList = res.data)))
      .subscribe();
  }
}
