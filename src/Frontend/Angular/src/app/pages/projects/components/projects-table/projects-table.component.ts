import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProjectList } from '../../interfaces/project-list.interface';

@Component({
  selector: 'app-projects-table',
  templateUrl: './projects-table.component.html',
  styleUrls: ['./projects-table.component.scss'],
})
export class ProjectsTableComponent {
  @Input() projectsList!: ProjectList[];
  @Output() btnEditProjectClick: EventEmitter<string> = new EventEmitter();

  editProject(projectId: string) {
    this.btnEditProjectClick.emit(projectId);
  }
}
