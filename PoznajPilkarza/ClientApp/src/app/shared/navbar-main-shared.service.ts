import { Injectable, Output, EventEmitter } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class NavbarMainSharedService {
  private _navItemSource = new BehaviorSubject<boolean>(false);

  navItem$ = this._navItemSource.asObservable();

  changeNav(open) {
    this._navItemSource.next(open);
  }
}
