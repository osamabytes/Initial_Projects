import { Component, OnInit } from '@angular/core';
import { BookshopsService } from 'src/app/services/bookshops.service';
import {ToastrService} from 'ngx-toastr';
import { BookShop } from 'src/app/models/bookshop.model';

@Component({
  selector: 'app-createbookshop',
  templateUrl: './createbookshop.component.html',
  styleUrls: ['./createbookshop.component.css']
})
export class CreatebookshopComponent implements OnInit {

  bookshop: BookShop = {
    Id: '00000000-0000-0000-0000-000000000000',
    Name: '',
  }

  constructor(private bookShopService: BookshopsService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.bookShopService.GetUserBookShop()
    .subscribe({
      next: (response: any) => {

        var bs = response.bookshop;

        this.bookshop = {
          Id: bs.id,
          Name: bs.name
        };

        console.log(this.bookshop);
      },
      error: (error) => {
        var errors = error.error.errors;

        errors.forEach(element => {
          this.toast.error(element, 'Bookify');
        });
      }
    })
  }

  CreateBookshopForm(){
    this.bookShopService.Add(this.bookshop)
    .subscribe({
      next: (response: any) => {
        this.bookshop = {
          Id: response.id,
          Name: response.name,
        };

        this.toast.success('Book Shop Operation Done Successfully', 'Bookify');
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
