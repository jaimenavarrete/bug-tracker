import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { tap } from 'rxjs';
import { CreateProject } from '../../interfaces/create-project.interface';
import { GroupList } from '../../interfaces/group-list.interface';
import { ProjectStateList } from '../../interfaces/project-state-list.interface';
import { GroupsService } from '../../services/groups.service';
import { ProjectStatesService } from '../../services/project-states.service';
import { ProjectsService } from '../../services/projects.service';

@Component({
  selector: 'app-create-project-modal',
  templateUrl: './create-project-modal.component.html',
  styleUrls: ['./create-project-modal.component.scss'],
})
export class CreateProjectModalComponent implements OnInit {
  groupsList!: GroupList[];
  projectStatesList!: ProjectStateList[];
  isLoading: boolean = false;
  @Output() projectCreated = new EventEmitter<boolean>();

  model: CreateProject = {
    name: '',
    description: undefined,
    ticketsPrefix: '',
    ownerId: '',
    startDate: undefined,
    completionDate: undefined,
    stateId: '',
    groupId: undefined,
    assignedTagsId: undefined,
  };

  constructor(
    private projectsService: ProjectsService,
    private groupsService: GroupsService,
    private projectStatesService: ProjectStatesService
  ) {}

  ngOnInit(): void {
    this.getGroups();
    this.getProjectStates();
  }

  onSubmit({ value: formData, valid: isValid }: NgForm) {
    if (isValid) {
      this.isLoading = true;

      this.createProject(formData);

      setTimeout(() => {
        this.isLoading = false;
        this.projectCreated.emit(true);
      }, 250);
    } else {
      alert('The form is invalid');
    }
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
      .pipe(tap((res) => console.log(res)))
      .subscribe();
  }
}
