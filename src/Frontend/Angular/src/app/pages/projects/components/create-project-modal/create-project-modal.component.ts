import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { tap } from 'rxjs';
import { CreateProject } from '../../interfaces/create-project.interface';
import { GroupList } from '../../interfaces/group-list.interface';
import { ProjectStateList } from '../../interfaces/project-state-list.interface';
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

  @Input() groupsList!: GroupList[];
  @Input() projectStatesList!: ProjectStateList[];

  model!: CreateProject;
  inputTagName!: string;
  assignedTagsList!: ProjectTagList[];
  isLoading: boolean = false;

  constructor(private projectsService: ProjectsService) {}

  ngOnInit(): void {
    this.clearModel();
  }

  onSubmit({ valid: isValid }: NgForm) {
    if (isValid) {
      this.isLoading = true;
      this.createProject(this.model);
    } else {
      alert('The form is invalid');
    }
  }

  clearModel(): void {
    this.model = {
      id: '',
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
