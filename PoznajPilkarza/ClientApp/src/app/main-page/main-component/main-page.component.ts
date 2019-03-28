import { Component, OnInit, HostListener } from '@angular/core';
import { NavbarMainSharedService } from '../../shared/navbar-main-shared.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  innerWidth: number;
  hamburgerOpen: boolean;
  subscription: Subscription;
  constructor(private navbarSharedService: NavbarMainSharedService) {
    this.hamburgerOpen = false;
    this.navbarSharedService = navbarSharedService;
    this.getScreenSize();
  }
  @HostListener('window:resize', ['$event'])
  getScreenSize(event?) {
    this.innerWidth = window.innerWidth;
    if (innerWidth >= 601) {
      this.hamburgerOpen = false;
    }
  }
  ngOnInit() {
    this.subscription = this.navbarSharedService.navItem$
      .subscribe(item => this.hamburgerOpen = item);
  }

}
