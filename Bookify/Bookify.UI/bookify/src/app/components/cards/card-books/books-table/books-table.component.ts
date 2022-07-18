import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-books-table',
  templateUrl: './books-table.component.html',
  styleUrls: ['./books-table.component.css']
})
export class BooksTableComponent implements OnInit {

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
