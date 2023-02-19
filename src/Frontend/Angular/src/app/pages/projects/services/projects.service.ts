import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { ApiResponse } from 'src/app/shared/interfaces/api-response.interface';
import { CreateProject } from '../interfaces/create-project.interface';
import { ProjectList } from '../interfaces/project-list.interface';
import { Project } from '../interfaces/project.interface';

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

  getProjectById(projectId: string): Observable<ApiResponse<Project>> {
    const url = `${this.apiURL}/${projectId}`;
    return this.http.get<ApiResponse<Project>>(url);
  }

  createProject(project: CreateProject): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(this.apiURL, project);
  }

  updateProject(project: CreateProject): Observable<any> {
    const url = `${this.apiURL}/${project.id}`;
    return this.http.put(url, project);
  }

  deleteProject(projectId: string): Observable<any> {
    const url = `${this.apiURL}/${projectId}`;
    return this.http.delete(url);
  }
}
