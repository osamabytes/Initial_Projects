import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { createPopper } from '@popperjs/core';

@Component({
  selector: 'app-admin-customer-dropdown',
  templateUrl: './admin-customer-dropdown.component.html',
  styleUrls: ['./admin-customer-dropdown.component.css']
})
export class AdminCustomerDropdownComponent implements AfterViewInit {

  dropdownshow = false;
  
  @ViewChild("btnDropDown", {static: false}) btnDropDown: ElementRef;
  @ViewChild("popoverDropDown", {static: false}) popoverDropDown: ElementRef;

  constructor() { }
  
  ngAfterViewInit(): void {
    createPopper(
      this.btnDropDown.nativeElement,
      this.popoverDropDown.nativeElement,
      {
        placement: "bottom-start"
      }
    );
  }

  ngOnInit(): void {
  }

  toggleDropDown(event){
    event.preventDefault();

    if(this.dropdownshow){
      this.dropdownshow = false;
    }else{
      this.dropdownshow = true;
    }
  }

}
