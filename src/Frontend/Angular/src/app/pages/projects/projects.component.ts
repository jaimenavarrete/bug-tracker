import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { GroupList } from './interfaces/group-list.interface';
import { ProjectList } from './interfaces/project-list.interface';
import { ProjectStateList } from './interfaces/project-state-list.interface';
import { GroupsService } from './services/groups.service';
import { ProjectStatesService } from './services/project-states.service';
import { ProjectsService } from './services/projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
})
export class ProjectsComponent implements OnInit {
  projectsList!: ProjectList[];
  groupsList!: GroupList[];
  projectStatesList!: ProjectStateList[];

  constructor(
    private projectsService: ProjectsService,
    private groupsService: GroupsService,
    private projectStatesService: ProjectStatesService
  ) {}

  ngOnInit(): void {
    this.getProjects();
    this.getGroups();
    this.getProjectStates();
  }

  private getProjects(): void {
    this.projectsService.projectsListAction$.subscribe(
      (res) => (this.projectsList = res.data)
    );
  }

  private getGroups(): void {
    this.groupsService
      .getGroups()
      .pipe(tap((res) => (this.groupsList = res.data)))
      .subscribe();
  }

  private getProjectStates(): void {
    this.projectStatesService
      .getProjectStates()
      .pipe(tap((res) => (this.projectStatesList = res.data)))
      .subscribe();
  }
}
