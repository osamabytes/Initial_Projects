import { Component, Input, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book.model';
import { BooksService } from 'src/app/services/books.service';
import {ToastrService} from 'ngx-toastr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-books-table',
  templateUrl: './books-table.component.html',
  styleUrls: ['./books-table.component.css']
})
export class BooksTableComponent implements OnInit {

  @Input()
  get color(){
    return this._color;
  }
  set color(color: string){
    this._color = color !== "light" && color !== "dark" ? "light" : color;
  }

  private _color = "light";

  books: Book[] = [];
  baseUrl: string = environment.baseUrl;

  constructor(private booksService: BooksService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.booksService.All()
    .subscribe({
      next: (response: any) => {

        response.forEach(row => {
          // setting the image path
          if(row.pic1 != ''){
            row.pic1 = this.baseUrl + `uploads/${row.pic1}`;
          }else{
            row.pic1 = this.baseUrl + `uploads/default.png`;
          }

          if(row.pic2 != ''){
            row.pic2 = this.baseUrl + `uploads/${row.pic2}`;
          }else{
            row.pic2 = this.baseUrl + `uploads/default.png`;
          }
        });

        this.books = response;
        console.log(this.books);
      },
      error: (error) => {
        var errors = error.error.errors;

        errors.forEach(element => {
          this.toast.error(element, 'Bookify');
        });
      }
    })
  }

}
