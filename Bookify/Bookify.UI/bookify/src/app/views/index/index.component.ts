import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { StorageService } from "src/app/services/Shared/storage.service";

@Component({
  selector: "app-index",
  templateUrl: "./index.component.html",
})
export class IndexComponent implements OnInit {
  constructor(private storage: StorageService, private route: Router) {
    if(storage.Get('token') != null){
      this.route.navigate(['admin']);
    }
  }

  ngOnInit(): void {
  }
}
