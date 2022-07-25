import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import {ToastrService} from 'ngx-toastr';
import { Type } from "src/app/models/type.model";
import { AuthenticationService } from "src/app/services/Shared/authentication.service";
import { UsertypeService } from "src/app/services/Shared/usertype.service";

@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
})
export class SidebarComponent implements OnInit {
  collapseShow = "hidden";

  SuperAdminUid: string;
  AdminUid: string;
  CustomerUid: string;

  userType: Type = {
    Id: '00000000-0000-0000-0000-000000000000',
    Name: ''
  };

  constructor(private route: Router, private utService: UsertypeService, private auth: AuthenticationService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.SuperAdminUid = this.utService.GetSuperAdminUid();
    this.AdminUid = this.utService.GetAdminUid();
    this.CustomerUid = this.utService.GetCustomerUid();

    this.utService.GetType()
    .subscribe({
      next: (response: any) => {
        
        this.userType = {
          Id: response.id.toUpperCase(),
          Name: response.name.toUpperCase()
        }
      },
      error: (error) => {
        var errors = error.error.errors;
        
        if(!this.auth.CheckLoginStatus(error.status)){
          this.route.navigate(['']);
        }

        errors.forEach(element => {
          this.toastr.error(element, 'Bookify');
        });
      }
    });
  }

  toggleCollapseShow(classes) {
    this.collapseShow = classes;
  }
}
