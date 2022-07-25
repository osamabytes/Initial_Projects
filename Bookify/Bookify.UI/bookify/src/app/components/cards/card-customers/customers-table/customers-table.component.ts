import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/users.service';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-customers-table',
  templateUrl: './customers-table.component.html',
  styleUrls: ['./customers-table.component.css']
})
export class CustomersTableComponent implements OnInit {

  @Input()
  get color(){
    return this._color;
  }
  set color(color: string){
    this._color = color !== "light" && color !== "dark" ? "light" : color;
  }

  private _color = "light";

  users: User[] = [];

  constructor(private userService: UsersService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.userService.AllUsers()
    .subscribe({
      next: (response) => {
        this.users = response;
        console.log(this.users);
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
