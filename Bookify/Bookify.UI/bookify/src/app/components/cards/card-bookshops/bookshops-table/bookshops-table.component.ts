import { Component, Input, OnInit } from '@angular/core';
import { UserBookShop } from 'src/app/models/User_BookShop.model';
import { BookshopsService } from 'src/app/services/bookshops.service';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-bookshops-table',
  templateUrl: './bookshops-table.component.html',
  styleUrls: ['./bookshops-table.component.css']
})
export class BookshopsTableComponent implements OnInit {

  @Input()
  get color(){
    return this._color;
  }
  set color(color: string){
    this._color = color !== "light" && color !== "dark" ? "light" : color;
  }

  private _color = "light";

  bookshops: UserBookShop[] = [];
  
  constructor(private bookshopService: BookshopsService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.bookshopService.All()
    .subscribe({
      next: (response) => {
        this.bookshops = response;
        console.log(this.bookshops);
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
