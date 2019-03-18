import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Manager } from 'src/app/models/manager';

@Injectable({
  providedIn: 'root'
})
export class ManagersService {

  private apiUrl = 'http://localhost:1234/api/managers/';
  concatApiUrl: string;

  constructor(private http: HttpClient) { }
  getPlayers(): Observable<Manager[]> {
    this.concatApiUrl = 'http://localhost:1234/api/managers/';
    return this.http.get<Manager[]>(this.concatApiUrl);
  }
  getPlayersWithLeague(league: string): Observable<Manager[]> {
    this.concatApiUrl = this.apiUrl + `league/${league}`;
    return this.http.get<Manager[]>(this.concatApiUrl);
  }
  getPlayersWithLeagueAndCountry(league: string, country: string): Observable<Manager[]> {
    this.apiUrl = this.apiUrl + `${country}/${league}`;
    return this.http.get<Manager[]>(this.apiUrl);
  }
  getPlayersWithCountry(country: string) {
    this.apiUrl = this.apiUrl + `country/${country}`;
    return this.http.get<Manager[]>(this.apiUrl);
  }
}
