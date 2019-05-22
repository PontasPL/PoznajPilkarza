import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SendTeamService {

  private sourceFirstTeam = new Subject<object>();
  currentFirstTeam = this.sourceFirstTeam.asObservable();


  private sourceSecondTeam = new Subject<object>();
  currentSecondTeam = this.sourceSecondTeam.asObservable();

  private sourceFirstTeamName = new Subject<string>();
  currentFirstTeamName = this.sourceFirstTeamName.asObservable();

  private sourceSecondTeamName = new Subject<string>();
  currentSecondTeamName = this.sourceSecondTeamName.asObservable();

  changeFirstTeam(team: object) {
    this.sourceFirstTeam.next(team);
  }

  changeSecondTeam(team: object) {
    this.sourceSecondTeam.next(team);
  }
  changeSecondName(nameTeam: string) {
    this.sourceSecondTeamName.next(nameTeam);
  }

  changeFirstName(nameTeam: string) {
    this.sourceFirstTeamName.next(nameTeam);
  }


}
