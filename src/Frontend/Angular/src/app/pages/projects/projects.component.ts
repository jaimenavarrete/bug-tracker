import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import Swal from 'sweetalert2';
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

  deleteProjectConfirmation(projectId: string): void {
    Swal.fire({
      title: 'Are you sure to delete this project?',
      text: "This action can't be undone. This will delete all the elements of the project.",
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'Yes. Delete it',
      confirmButtonColor: '#C12A32',
    }).then((result) => {
      if (result.isConfirmed) {
        this.deleteProject(projectId);
      }
    });
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

  private deleteProject(projectId: string): void {
    this.projectsService
      .deleteProject(projectId)
      .pipe(
        tap(() => {
          this.projectsService.projectsListSubjectUpdate();
          this.showCompletionAlert('The project was deleted successfully!');
        })
      )
      .subscribe();
  }

  private showCompletionAlert(successMessage: string): void {
    Swal.fire({
      title: 'Success!',
      text: successMessage,
      icon: 'success',
    });
  }
}
