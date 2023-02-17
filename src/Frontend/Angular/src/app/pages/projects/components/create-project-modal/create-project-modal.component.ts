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

@Component({
  selector: 'app-create-project-modal',
  templateUrl: './create-project-modal.component.html',
  styleUrls: ['./create-project-modal.component.scss'],
})
export class CreateProjectModalComponent implements OnInit {
  @ViewChild('closeModalButton') closeModalButton!: ElementRef;

  groupsList!: GroupList[];
  projectStatesList!: ProjectStateList[];
  projectTagsList = [
    {
      id: 'ee84a39d-06bf-44a7-bf3b-1930a10945a6',
      name: 'Tag1',
      colorHexCode: '#FF0000',
    },
    {
      id: 'c17a00b9-3aa1-4518-b1ce-6a46a456f1c1',
      name: 'Tag2',
      colorHexCode: '#00FF00',
    },
  ];

  model!: CreateProject;
  inputTagName = '';
  assignedTagsList!: { id: string; name: string; colorHexCode: string }[];
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

  addAssignedTag(event: KeyboardEvent): void {
    if (event.key === ',') {
      let tagName = this.inputTagName.replaceAll(',', '').trim();
      tagName = tagName.toLowerCase();

      let newTag = this.projectTagsList.find(
        (tag) => tag.name.toLowerCase() === tagName
      );

      if (newTag) {
        this.inputTagName = '';
        this.model.assignedTagsId?.push(newTag.id);
        this.assignedTagsList?.push(newTag);
      }
    }
  }

  removeAssignedTag(assignedTagId: string): void {
    let tagIndex = this.model.assignedTagsId?.indexOf(assignedTagId);

    if (tagIndex !== undefined && tagIndex !== -1) {
      this.model.assignedTagsId?.splice(tagIndex, 1);
      this.assignedTagsList?.splice(tagIndex, 1);
    }
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
