import { GroupMini } from './group-list.interface';
import { ProjectStateMini } from './project-state-list.interface';
import { ProjectTagMini } from './project-tag.interface';

export interface Project {
  id: string;
  name: string;
  description: string;
  ticketsPrefix: string;
  ownerId: string;
  state: ProjectStateMini;
  startDate: Date;
  completionDate: Date;
  group: GroupMini;
  assignedTags: ProjectTagMini[];
  creationDate: Date;
  createdBy: string;
  lastModificationDate: Date;
  modifiedBy: string;
}
