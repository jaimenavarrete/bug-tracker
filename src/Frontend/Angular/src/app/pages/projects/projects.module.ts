import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectsTableComponent } from './components/projects-table/projects-table.component';
import { CreateProjectModalComponent } from './components/create-project-modal/create-project-modal.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ProjectsComponent,
    ProjectsTableComponent,
    CreateProjectModalComponent,
  ],
  imports: [CommonModule, ProjectsRoutingModule, FormsModule],
})
export class ProjectsModule {}
