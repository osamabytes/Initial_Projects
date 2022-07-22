import { Component, OnInit } from "@angular/core";
import { UserRegistrationDto } from "src/app/interfaces/UserRegistrationDto.interface";
import { AuthenticationService } from "src/app/services/Shared/authentication.service";

import {ToastrService} from 'ngx-toastr';
import { NgForm } from "@angular/forms";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
})
export class RegisterComponent implements OnInit {
  firstNameError: string;
  emailError: string;
  passwordError: string;
  confirmPasswordError: string;
  typeIdError: string;

  UserRegisterDto: UserRegistrationDto = {
    Id: '00000000-0000-0000-0000-000000000000',
    FirstName: '',
    LastName: '',
    Email: '',
    Password: '',
    ConfirmPassword: '',
    TypeId: "00000000-0000-0000-0000-000000000000",
  };

  constructor(private authenticationService: AuthenticationService, private toastr: ToastrService) {}

  ngOnInit(): void {}

  RegisterUser(register: NgForm){
    this.authenticationService.registerUser("api/users/Register", this.UserRegisterDto)
    .subscribe({
      next: (response: any) => {
        console.log(response);
        if(response.isSuccessfulRegister === true){

          // empty all values
          this.firstNameError = "";
          this.emailError = "";
          this.passwordError = "";
          this.confirmPasswordError = "";
          this.typeIdError = "";

          // empty form
          register.reset();

          this.toastr.success("User Registered Successfully", 'Bookify');
        }
      },
      error: (error) => {
        console.log(error);

        let errors = error.error.errors;
        
        if(error.error.hasOwnProperty('isSuccessfulRegister')){
          errors.forEach(err => {
            this.toastr.error(err, 'Bookify');
          });
        }
        
        // set the errors for all
        if(errors.hasOwnProperty("FirstName")){
          this.firstNameError = errors.FirstName[0];
        }
        if(errors.hasOwnProperty("Email")){
          this.emailError = errors.Email[0];
        }
        if(errors.hasOwnProperty("Password")){
          this.passwordError = errors.Password[0];
        }
        if(errors.hasOwnProperty("ConfirmPassword")){
          this.confirmPasswordError = errors.ConfirmPassword[0];
        }
        if(errors.hasOwnProperty("TypeId")){
          this.typeIdError = errors.TypeId[0];
        }
      }
    })
  }

  Test(){
    this.toastr.success("Test");
  }
}
