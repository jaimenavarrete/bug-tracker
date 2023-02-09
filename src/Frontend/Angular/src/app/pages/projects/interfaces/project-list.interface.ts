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

export interface ProjectStateMini {
  id: string;
  name: string;
  colorHexCode: string;
}

export interface GroupMini {
  id: string;
  name: string;
}

export interface ProjectTagMini {
  id: string;
  name: string;
  colorHexCode: string;
}
