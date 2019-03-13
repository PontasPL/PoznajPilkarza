import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Player } from 'src/app/models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private apiUrl = 'http://localhost:1234/api/players';
  constructor(private http: HttpClient) { }

  getCars() {
    return this.http.get<Player[]>(this.apiUrl);
  }
  addInfo(country: string) {
    this.apiUrl = `http://localhost:1234/api/players/${country}`;
    return this.http.get<Player[]>(this.apiUrl);
  }
}
