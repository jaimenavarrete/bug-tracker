export interface CreateProject {
  id: string;
  name: string;
  description?: string;
  ticketsPrefix: string;
  ownerId: string;
  startDate?: Date;
  completionDate?: Date;
  stateId: string;
  groupId?: string;
  assignedTagsId?: string[];
}
