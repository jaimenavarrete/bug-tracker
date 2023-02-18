import { Component, Input, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { ProjectTagList } from '../../../interfaces/project-tag.interface';
import { ProjectTagsService } from '../../../services/project-tags.service';

@Component({
  selector: 'app-assigned-tags-input',
  templateUrl: './assigned-tags-input.component.html',
})
export class AssignedTagsInputComponent implements OnInit {
  projectTagsList!: ProjectTagList[];

  @Input() inputTagName!: string;
  @Input() assignedTagsId?: string[];
  @Input() assignedTagsList!: ProjectTagList[];

  constructor(private projectTagsService: ProjectTagsService) {}

  ngOnInit(): void {
    this.clearTags();

    this.getProjectTags();
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
        this.assignedTagsId?.push(newTag.id);
        this.assignedTagsList?.push(newTag);
      }
    }
  }

  removeAssignedTag(assignedTagId: string): void {
    let tagIndex = this.assignedTagsId?.indexOf(assignedTagId);

    if (tagIndex !== undefined && tagIndex !== -1) {
      this.assignedTagsId?.splice(tagIndex, 1);
      this.assignedTagsList?.splice(tagIndex, 1);
    }
  }

  private clearTags(): void {
    this.inputTagName = '';
    this.assignedTagsList = [];
  }

  private getProjectTags(): void {
    this.projectTagsService
      .getProjectTags()
      .pipe(tap((res) => (this.projectTagsList = res.data)))
      .subscribe();
  }
}
