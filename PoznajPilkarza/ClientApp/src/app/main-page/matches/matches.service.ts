import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Match } from 'src/app/models/match';
import { IMatchDetails } from 'src/app/models/matchDetails';

@Injectable({
  providedIn: 'root'
})
export class MatchesService {

  private apiUrl = 'http://localhost:1234/api/matches';
  concatApiUrl: string;

  constructor(private http: HttpClient) { }
  getMatches(): Observable<Match[]> {
    this.concatApiUrl = this.apiUrl;
    return this.http.get<Match[]>(this.concatApiUrl);
  }
  getMatchesWithLeague(league: string): Observable<Match[]> {
    this.concatApiUrl = this.apiUrl + `/league/${league}`;
    return this.http.get<Match[]>(this.concatApiUrl);
  }
  getMatchesWithDetails(): Observable<Match[]> {
    this.concatApiUrl = this.apiUrl + '/withdetails';
    return this.http.get<IMatchDetails[]>(this.concatApiUrl);
  }
  getMatchesWithDetailsAndLeague(league: string): Observable<Match[]> {
    this.concatApiUrl = this.apiUrl + `/withdetails/league/${league}`;
    return this.http.get<IMatchDetails[]>(this.concatApiUrl);
  }
}
