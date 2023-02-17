import { GroupMini } from './group-list.interface';
import { ProjectStateMini } from './project-state-list.interface';
import { ProjectTagMini } from './project-tag.interface';

export interface ProjectList {
  id: string;
  name: string;
  ticketsPrefix: string;
  ownerId: string;
  state: ProjectStateMini;
  startDate: Date;
  completionDate: Date;
  group: GroupMini;
  assignedTags: ProjectTagMini[];
}
