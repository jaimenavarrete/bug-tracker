import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { tap } from 'rxjs';
import { CreateProject } from '../../interfaces/create-project.interface';
import { GroupList } from '../../interfaces/group-list.interface';
import { ProjectStateList } from '../../interfaces/project-state-list.interface';
import { GroupsService } from '../../services/groups.service';
import { ProjectStatesService } from '../../services/project-states.service';

@Component({
  selector: 'app-create-project-modal',
  templateUrl: './create-project-modal.component.html',
  styleUrls: ['./create-project-modal.component.scss'],
})
export class CreateProjectModalComponent implements OnInit {
  groupsList!: GroupList[];
  projectStatesList!: ProjectStateList[];

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
    private groupsService: GroupsService,
    private projectStatesService: ProjectStatesService
  ) {}

  ngOnInit(): void {
    this.getGroups();
    this.getProjectStates();
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      alert('The form is valid');
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
}
