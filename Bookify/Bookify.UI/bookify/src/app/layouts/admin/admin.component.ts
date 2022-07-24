import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { StorageService } from "src/app/services/Shared/storage.service";

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
})
export class AdminComponent implements OnInit {
  constructor(private route: Router, private storage: StorageService) {
    console.log(storage.Get('token'));
    if(storage.Get('token') == null){
      this.route.navigate(['']);
    }
  }

  ngOnInit(): void {}
}
