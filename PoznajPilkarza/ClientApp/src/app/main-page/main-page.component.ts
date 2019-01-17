import { Component, OnInit, HostListener, ElementRef, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  // checkMobile = false;

  constructor() { }

  ngOnInit() {
    // this.ResizeSearchText();
  }

  // public ResizeSearchText() {
  //   if (window.innerWidth < 601) {
  //     this.checkMobile = true;
  //   }
  //   console.log(window.innerWidth);
  // }
}
