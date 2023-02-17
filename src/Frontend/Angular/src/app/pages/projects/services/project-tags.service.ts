import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/shared/interfaces/api-response.interface';
import { ProjectTagList } from '../interfaces/project-tag.interface';

@Injectable({
  providedIn: 'root',
})
export class ProjectTagsService {
  private apiURL = 'https://localhost:7121/api/projectTags';

  constructor(private http: HttpClient) {}

  getProjectTags(): Observable<ApiResponse<ProjectTagList[]>> {
    return this.http.get<ApiResponse<ProjectTagList[]>>(this.apiURL);
  }
}
