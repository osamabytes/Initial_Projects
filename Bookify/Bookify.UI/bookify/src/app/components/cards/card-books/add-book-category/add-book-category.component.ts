import { Component, OnInit } from '@angular/core';
import {ToastrService} from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-add-book-category',
  templateUrl: './add-book-category.component.html',
  styleUrls: ['./add-book-category.component.css']
})
export class AddBookCategoryComponent implements OnInit {

  categories: Category[] = [];
  category: Category = {
    Id: "00000000-0000-0000-0000-000000000000",
    Name: "",
    Description: ""
  };

  constructor(private categoryService: CategoryService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.categoryService.All("api/category")
    .subscribe({
      next: (response) => {
        console.log(response);
        this.categories = response;
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  AddCategory(categoryForm: NgForm){
    this.categoryService.Add("api/category", this.category)
    .subscribe({
      next: (response) => {
        this.categories.push(response);
        this.toast.success("Category Added Successfully", 'Bookify');

        categoryForm.reset();
      },
      error: (error) => {
        var errors = error.error.errors;

        errors.forEach(item => {
          this.toast.error(item, 'Bookify');

          categoryForm.reset();
        });
      }
    })
  }
}
