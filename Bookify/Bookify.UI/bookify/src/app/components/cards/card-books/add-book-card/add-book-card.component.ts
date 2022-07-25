import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BooksService } from 'src/app/services/books.service';
import {ToastrService} from 'ngx-toastr';
import { BookCategoriesDto } from 'src/app/interfaces/BookCategoriesDto';
import { CategoryService } from 'src/app/services/category.service';

import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'app-add-book-card',
  templateUrl: './add-book-card.component.html',
  styleUrls: ['./add-book-card.component.css']
})
export class AddBookCardComponent implements OnInit {

  bookCategoriesDto: BookCategoriesDto = {
    Book: {
      Id: '00000000-0000-0000-0000-000000000000',
      Name: '',
      ISBN: '',
      Description: '',
      Pic1: '',
      Pic2: ''
    },
    Categories: []
  }

  ddList = [];
  ddSettings: IDropdownSettings = {
    idField: 'id',
    textField: 'name'
  };

  constructor(private bookService: BooksService, private categoryService: CategoryService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.categoryService.All("api/Category")
    .subscribe({
      next: (response) => {
        this.ddList = response;
      },
      error: (error) => {
        var errors = error.error.errors;

        errors.forEach(element => {
          this.toast.error(element, 'Bookify');
        });
      }
    })
  }

  AddBook(addbookform: NgForm){
    this.bookService.AddBook(this.bookCategoriesDto)
    .subscribe({
      next: (response) => {
        addbookform.reset();

        this.toast.success('Book Added Successfully', 'Bookify');
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
