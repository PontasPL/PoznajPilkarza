import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { IPlayer } from 'src/app/models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private apiUrl = 'http://localhost:1234/api/players/';
  concatApiUrl: string;
  constructor(private http: HttpClient) { }

  getPlayer(nameSurname: string): Observable<IPlayer> {
    this.concatApiUrl = this.apiUrl + nameSurname;
    return this.http.get<IPlayer>(this.concatApiUrl);
  }


  getPlayersNameSurname(): Observable<IPlayer[]> {
    this.concatApiUrl = this.apiUrl + 'names';
    return this.http.get<IPlayer[]>(this.concatApiUrl);
  }
  getPlayers(): Observable<IPlayer[]> {
    // this.apiUrl = 'http://localhost:1234/api/players/';
    return this.http.get<IPlayer[]>(this.apiUrl);
  }
  getPlayersWithLeague(league: string): Observable<IPlayer[]> {
    this.concatApiUrl = this.apiUrl + `league/${league}`;
    return this.http.get<IPlayer[]>(this.concatApiUrl);
  }
  getPlayersWithLeagueAndCountry(league: string, country: string): Observable<IPlayer[]> {
    this.concatApiUrl = this.apiUrl + `${country}/${league}`;
    return this.http.get<IPlayer[]>(this.concatApiUrl);
  }
  getPlayersWithCountry(country: string) {
    console.log(this.apiUrl);
    this.concatApiUrl = this.apiUrl + `country/${country}`;
    return this.http.get<IPlayer[]>(this.concatApiUrl);
  }
}
