import { Component, Input } from '@angular/core';
import { ProjectList } from '../../interfaces/projectList.interface';

@Component({
  selector: 'app-projects-table',
  templateUrl: './projects-table.component.html',
  styleUrls: ['./projects-table.component.scss'],
})
export class ProjectsTableComponent {
  @Input() projectsList!: ProjectList[];
}
