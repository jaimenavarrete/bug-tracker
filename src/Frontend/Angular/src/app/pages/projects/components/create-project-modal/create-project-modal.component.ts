import { Component } from '@angular/core';
import { CreateProject } from '../../interfaces/create-project.interface';

@Component({
  selector: 'app-create-project-modal',
  templateUrl: './create-project-modal.component.html',
  styleUrls: ['./create-project-modal.component.scss'],
})
export class CreateProjectModalComponent {
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

  constructor() {}

  createProjectSubmit() {
    alert(this.model.name);
  }
}
