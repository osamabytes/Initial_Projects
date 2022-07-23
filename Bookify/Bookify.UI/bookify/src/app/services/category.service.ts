import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseUrl: String = environment.baseUrl;

  constructor(private http: HttpClient) { }

  public All(route: string){
    return this.http.get<Category[]>(this.baseUrl + route);
  }

  public Add(route: string, body: Category){
    return this.http.post<Category>(this.baseUrl + route, body);
  }
}
