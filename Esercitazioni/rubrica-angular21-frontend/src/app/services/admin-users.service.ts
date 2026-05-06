import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import{Observable} from 'rxjs';
import { environment } from '../../environment/environments';
import { ChangeUserRoleRequest, ChangeUserRoleResponse } from '../models/change-user-role.model';
import { UserProfile } from '../models/user-profile.model';

@Injectable({
  providedIn: 'root',
})
export class AdminUsersService {
  private readonly http = inject(HttpClient);

  changeRole(payload : ChangeUserRoleRequest) : Observable<ChangeUserRoleResponse>
  {
    return this.http.put<ChangeUserRoleResponse>(`${environment.apiBaseUrl}/AdminUsers/change-role`, payload);
  }

  getAllUsers():Observable<UserProfile[]>
  {
    return this.http.get<UserProfile[]>(`${environment.apiBaseUrl}/AdminUsers/listaUtenti`);
  }
}
