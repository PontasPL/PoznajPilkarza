import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { League } from '../models/league';

@Injectable({
  providedIn: 'root'
})
export class LeagueService {

  private apiUrl = 'http://localhost:1234/api/leagues';
  constructor(private http: HttpClient) { }

  getLeagues() {
    return this.http.get<League[]>(this.apiUrl);
  }
}
