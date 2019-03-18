import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Player } from 'src/app/models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private apiUrl = 'http://localhost:1234/api/players/';
  concatApiUrl: string;
  constructor(private http: HttpClient) { }
  getPlayers(): Observable<Player[]> {
    // this.apiUrl = 'http://localhost:1234/api/players/';
    return this.http.get<Player[]>(this.apiUrl);
  }
  getPlayersWithLeague(league: string): Observable<Player[]> {
    this.concatApiUrl = this.apiUrl + `league/${league}`;
    return this.http.get<Player[]>(this.concatApiUrl);
  }
  getPlayersWithLeagueAndCountry(league: string, country: string): Observable<Player[]> {
    this.concatApiUrl = this.apiUrl + `${country}/${league}`;
    return this.http.get<Player[]>(this.concatApiUrl);
  }
  getPlayersWithCountry(country: string) {
    console.log(this.apiUrl);
    this.concatApiUrl = this.apiUrl + `country/${country}`;
    return this.http.get<Player[]>(this.concatApiUrl);
  }
}
