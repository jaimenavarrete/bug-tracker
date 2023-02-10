import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/shared/interfaces/api-response.interface';
import { ProjectStateList } from '../interfaces/project-state-list.interface';

@Injectable({
  providedIn: 'root',
})
export class ProjectStatesService {
  private apiURL = 'https://localhost:7121/api/projectStates';

  constructor(private http: HttpClient) {}

  getProjectStates(): Observable<ApiResponse<ProjectStateList[]>> {
    return this.http.get<ApiResponse<ProjectStateList[]>>(this.apiURL);
  }
}
