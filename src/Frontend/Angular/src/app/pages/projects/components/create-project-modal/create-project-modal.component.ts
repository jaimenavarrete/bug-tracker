import {
  Component,
  ElementRef,
  EventEmitter,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
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
  @ViewChild('closeModalButton') closeModalButton!: ElementRef;

  groupsList!: GroupList[];
  projectStatesList!: ProjectStateList[];

  model!: CreateProject;
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

  onSubmit({ value: formData, valid: isValid }: NgForm) {
    if (isValid) {
      this.isLoading = true;
      this.createProject(formData);
    } else {
      alert('The form is invalid');
    }
  }

  private clearModel(): void {
    this.model = {
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
          this.projectsService.projectsListSubjectUpdate();

          this.isLoading = false;
          this.closeModalButton.nativeElement.click();
          this.clearModel();
        })
      )
      .subscribe();
  }
}
