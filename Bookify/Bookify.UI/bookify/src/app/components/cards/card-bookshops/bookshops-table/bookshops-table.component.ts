import { Component, Input, OnInit } from '@angular/core';

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
  
  constructor() { }

  ngOnInit(): void {
  }

}
