import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserBookShop } from '../models/User_BookShop.model';

@Injectable({
  providedIn: 'root'
})
export class BookshopsService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  public All(){
    return this.http.get<UserBookShop[]>(this.baseUrl + "api/Bookshop");
  }
}
