import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { ApiResponse } from 'src/app/shared/interfaces/api-response.interface';
import { CreateProject } from '../interfaces/create-project.interface';
import { ProjectList } from '../interfaces/project-list.interface';

@Injectable({
  providedIn: 'root',
})
export class ProjectsService {
  private apiURL = 'https://localhost:7121/api/projects';
  private projectsListSubject = new ReplaySubject<ApiResponse<ProjectList[]>>();

  constructor(private http: HttpClient) {}

  get projectsListAction$(): Observable<ApiResponse<ProjectList[]>> {
    return this.projectsListSubject.asObservable();
  }

  projectsListSubjectUpdate(): void {
    this.getProjects().subscribe((res) => this.projectsListSubject.next(res));
  }

  private getProjects(): Observable<ApiResponse<ProjectList[]>> {
    return this.http.get<ApiResponse<ProjectList[]>>(this.apiURL);
  }

  createProject(project: CreateProject): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(this.apiURL, project);
  }
}
