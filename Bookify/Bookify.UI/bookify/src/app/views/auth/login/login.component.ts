import { Component, OnInit } from "@angular/core";
import { UserForAuthenticationDto } from "src/app/interfaces/UserForAuthenticationDto.interface";
import { AuthenticationService } from "src/app/services/Shared/authentication.service";

import {ToastrService} from 'ngx-toastr';
import { NgForm } from "@angular/forms";
import { StorageService } from "src/app/services/Shared/storage.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
})
export class LoginComponent implements OnInit {
  emailError: string;
  passwordError: string;

  UserAuth: UserForAuthenticationDto = {
    Email: '',
    Password : ''
  };

  constructor(private authentication: AuthenticationService, private storage: StorageService, private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {}

  Login(login: NgForm){
    this.authentication.loginUser('api/users/Login', this.UserAuth)
    .subscribe({
      next: (response: any) => {
        console.log(response);

        if(response.isAuthSuccessful === true){
          this.emailError = "";
          this.passwordError = "";

          login.reset();

          this.storage.Save('token', response.token);

          this.toastr.success("Login Successful!", 'Bookify');

          // navigate to admin
          this.router.navigate(['admin']);
        }
      },
      error: (error) => {
        var errors = error.error.errors;

        console.log(error);

        if(error.error.hasOwnProperty('isAuthSuccessful')){
          this.toastr.error(error.error.errorMessage, 'Bookify');

          this.emailError = "";
          this.passwordError = "";
        }

        if(errors !== undefined){
          if(errors.hasOwnProperty('Email')){
            this.emailError = errors.Email[0];
          }else{
            this.emailError = "";
          }

          if(errors.hasOwnProperty('Password')){
            this.passwordError = errors.Password[0];
          }else {
            this.passwordError = "";
          }
        }
      }
     })
  }
}
