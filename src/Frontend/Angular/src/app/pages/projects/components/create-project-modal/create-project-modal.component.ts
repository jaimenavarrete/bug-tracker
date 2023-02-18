import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { tap } from 'rxjs';
import { CreateProject } from '../../interfaces/create-project.interface';
import { GroupList } from '../../interfaces/group-list.interface';
import { ProjectStateList } from '../../interfaces/project-state-list.interface';
import { GroupsService } from '../../services/groups.service';
import { ProjectStatesService } from '../../services/project-states.service';
import { ProjectsService } from '../../services/projects.service';

import Swal from 'sweetalert2';
import { ProjectTagList } from '../../interfaces/project-tag.interface';
@Component({
  selector: 'app-create-project-modal',
  templateUrl: './create-project-modal.component.html',
  styleUrls: ['./create-project-modal.component.scss'],
})
export class CreateProjectModalComponent implements OnInit {
  @ViewChild('closeModalButton') closeModalButton!: ElementRef;

  groupsList!: GroupList[];
  projectStatesList!: ProjectStateList[];

  model!: CreateProject;
  inputTagName!: string;
  assignedTagsList!: ProjectTagList[];
  isLoading: boolean = false;

  constructor(
    private projectsService: ProjectsService,
    private groupsService: GroupsService,
    private projectStatesService: ProjectStatesService
  ) {}

  ngOnInit(): void {
    this.clearModel();

    this.getGroups();
    this.getProjectStates();
  }

  onSubmit({ valid: isValid }: NgForm) {
    if (isValid) {
      this.isLoading = true;
      this.createProject(this.model);
    } else {
      alert('The form is invalid');
    }
  }

  private clearModel(): void {
    this.model = {
      name: '',
      description: '',
      ticketsPrefix: '',
      ownerId: '',
      startDate: undefined,
      completionDate: undefined,
      stateId: '',
      groupId: '',
      assignedTagsId: [],
    };

    this.inputTagName = '';
    this.assignedTagsList = [];
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

  private createProject(project: CreateProject) {
    this.projectsService
      .createProject(project)
      .pipe(
        tap((res) => {
          this.clearModel();

          this.projectsService.projectsListSubjectUpdate();
          this.closeCreateProjectModal();
          this.showCompletionAlert();
        })
      )
      .subscribe();
  }

  private closeCreateProjectModal(): void {
    this.isLoading = false;
    this.closeModalButton.nativeElement.click();
  }

  private showCompletionAlert(): void {
    Swal.fire({
      title: 'Success!',
      text: 'The project was created successfully!',
      icon: 'success',
      showCancelButton: true,
      cancelButtonText: 'Close',
      confirmButtonText: 'Go to project',
    });
  }
}
