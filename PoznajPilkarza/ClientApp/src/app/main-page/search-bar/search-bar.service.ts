import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Player } from '@angular/core/src/render3/interfaces/player';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchBarService {


  private apiUrl = 'http://localhost:1234/api/players/names';
  constructor(private http: HttpClient) { }

  getCars(): Observable<Player[]> {
    return this.http.get<Player[]>(this.apiUrl);
  }
}
