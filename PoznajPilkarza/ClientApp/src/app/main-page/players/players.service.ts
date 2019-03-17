import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Player } from 'src/app/models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private apiUrl = 'http://localhost:1234/api/players/names';
  constructor(private http: HttpClient) { }

  getCars(): Observable<Player[]> {
    return this.http.get<Player[]>(this.apiUrl);
  }
  getPlayersWithCountry(country: string) {
    this.apiUrl = `http://localhost:1234/api/players/country/${country}`;
    return this.http.get<Player[]>(this.apiUrl);
  }
}
