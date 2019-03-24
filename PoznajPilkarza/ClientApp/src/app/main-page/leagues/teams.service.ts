import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ITeam } from 'src/app/models/team';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeamsService {

  private apiUrl = 'http://localhost:1234/api/teams/';
  concatApiUrl: string;

  constructor(private http: HttpClient) { }
  GetTeams(): Observable<ITeam[]> {
    this.concatApiUrl = this.apiUrl;
    return this.http.get<ITeam[]>(this.concatApiUrl);
  }
  GetTeamInLeague(league: string): Observable<ITeam[]> {
    this.concatApiUrl = this.apiUrl + `league/${league}`;
    return this.http.get<ITeam[]>(this.concatApiUrl);
  }
}
