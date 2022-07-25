import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  public AllUsers(){
    return this.http.get<User[]>(this.baseUrl + "api/users/AllUsers");
  }
}
