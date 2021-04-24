import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/user';
import { UserDetail } from 'src/app/shared/models/user-deail';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }

  getAllUsers(): Observable<User[]> {
    return this.apiService.getAll('Users/allusers');
  }

  getUserAsync(id: number): Observable<UserDetail> {
    return this.apiService.getById(`${'Users'}`, id);
  }
}
