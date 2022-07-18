import { Component, Input, OnInit } from '@angular/core';

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

  constructor() { }

  ngOnInit(): void {
  }

}
