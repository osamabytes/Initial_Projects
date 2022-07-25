import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  public All(){
    return this.http.get<Book[]>(this.baseUrl + "api/Book");
  }
}
