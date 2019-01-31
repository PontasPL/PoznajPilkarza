import { Injectable, Output, EventEmitter } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class NavbarMainSharedService {
  // Observable navItem source
  private _navItemSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  navItem$ = this._navItemSource.asObservable();
  // service command
  changeNav(open) {
    console.log('jestem w service');
    this._navItemSource.next(open);
  }
}
