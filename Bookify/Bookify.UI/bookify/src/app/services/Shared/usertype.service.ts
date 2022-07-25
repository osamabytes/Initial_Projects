import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Type } from 'src/app/models/type.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsertypeService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  public GetType(): Observable<Type>{
    return this.http.get<Type>(this.baseUrl + "api/users/GetUserType");
  }

  public GetSuperAdminUid(){
    return "9F6677E8-8E35-4005-8211-DF565C5034F9";
  }

  public GetAdminUid(){
    return "2FC8A3BA-5FE2-4611-8A56-B1BA30639F8B";
  }

  public GetCustomerUid(){
    return "5CA2B79B-EA4C-4B2D-912E-57F164EC9C4D";
  }
}
