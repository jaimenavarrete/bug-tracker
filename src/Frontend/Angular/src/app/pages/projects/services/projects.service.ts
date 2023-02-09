import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/shared/interfaces/api-response.interface';
import { ProjectList } from '../interfaces/project-list.interface';

@Injectable({
  providedIn: 'root',
})
export class ProjectsService {
  private apiURL = 'https://localhost:7121/api/projects';

  constructor(private http: HttpClient) {}

  getProjects(): Observable<ApiResponse<ProjectList[]>> {
    return this.http.get<ApiResponse<ProjectList[]>>(this.apiURL);
  }
}
