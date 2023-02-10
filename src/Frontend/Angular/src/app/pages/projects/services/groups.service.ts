import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/shared/interfaces/api-response.interface';
import { GroupList } from '../interfaces/group-list.interface';

@Injectable({
  providedIn: 'root',
})
export class GroupsService {
  private apiURL = 'https://localhost:7121/api/groups';

  constructor(private http: HttpClient) {}

  getGroups(): Observable<ApiResponse<GroupList[]>> {
    return this.http.get<ApiResponse<GroupList[]>>(this.apiURL);
  }
}
