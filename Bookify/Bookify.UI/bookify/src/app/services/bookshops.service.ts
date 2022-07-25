import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BookShop } from '../models/bookshop.model';
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

  public Add(body: BookShop){
    return this.http.post<BookShop>(this.baseUrl + "api/Bookshop", body);
  }

  public GetUserBookShop(){
    return this.http.get<UserBookShop>(this.baseUrl + "api/Bookshop/UserBookShop");
  }
}
