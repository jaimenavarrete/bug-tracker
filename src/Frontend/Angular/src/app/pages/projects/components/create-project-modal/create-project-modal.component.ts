import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { tap } from 'rxjs';
import { CreateProject } from '../../interfaces/create-project.interface';
import { GroupList } from '../../interfaces/group-list.interface';
import { GroupsService } from '../../services/groups.service';

@Component({
  selector: 'app-create-project-modal',
  templateUrl: './create-project-modal.component.html',
  styleUrls: ['./create-project-modal.component.scss'],
})
export class CreateProjectModalComponent implements OnInit {
  groupsList!: GroupList[];

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

  constructor(private groupsService: GroupsService) {}

  ngOnInit(): void {
    this.getGroups();
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
}
