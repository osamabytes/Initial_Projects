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
    Categories: [],
    Image1: null,
    Image2: null,
  }

  ddList = [];
  selectedItems = [];
  ddSettings: IDropdownSettings = {
    idField: 'id',
    textField: 'name',
    allowSearchFilter: true
  };

  image1: File = null;
  image2: File = null;

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

  handleUploadImage(event){
    var elementId = event.target.id;

    if(elementId == 'pic1'){
      this.image1 = <File>event.target.files[0];
    }else{
      this.image2 = <File>event.target.files[0];
    }
  }

  AddBook(addbookform: NgForm){

    // Add the images name to the recpective model variables
    if(this.image1 != null){
      this.bookCategoriesDto.Book.Pic1 = this.image1.name;
      this.bookCategoriesDto.Image1 = this.image1;
    }

    if(this.image2 != null){
      this.bookCategoriesDto.Book.Pic2 = this.image2.name;
      this.bookCategoriesDto.Image2 = this.image2;
    }

    this.selectedItems.forEach(item => {
      this.bookCategoriesDto.Categories.push({
        Id: item.id,
        Name: item.name,
        Description: ''
      })
    });

    const formData = new FormData();
    formData.append('Book', JSON.stringify(this.bookCategoriesDto.Book));
    formData.append('Categories', JSON.stringify(this.bookCategoriesDto.Categories));
    formData.append('Image1', this.bookCategoriesDto.Image1);
    formData.append('Image2', this.bookCategoriesDto.Image2);

    this.bookService.AddBook(formData)
    .subscribe({
      next: (response) => {
        addbookform.reset();
        this.toast.success('Book Added Successfully', 'Bookify');
      },
      error: (error) => {
        if(error.error.hasOwnProperty('errors')){
          var errors = error.error.errors;
          errors.forEach(element => {
            this.toast.error(element, 'Bookify');
          });
        }

        if(error.status == 500){
          this.toast.error("Internal Server Error", 'Bookify');
        }

        console.log(error);
      }
    });
  }
}
