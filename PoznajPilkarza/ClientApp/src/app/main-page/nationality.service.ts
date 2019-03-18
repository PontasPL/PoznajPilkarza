import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { INationality } from '../models/nationality';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NationalityService {

  private apiUrl = 'http://localhost:1234/api/nationalities/';
  concatApiUrl: string;
  constructor(private http: HttpClient) { }

  getNationalityPlayers() {
    this.concatApiUrl = this.apiUrl + 'players';
    return this.http.get<INationality[]>(this.concatApiUrl);
  }
  getNationalityManagers() {
    this.concatApiUrl = this.apiUrl + 'managers';
    return this.http.get<INationality[]>(this.concatApiUrl);
  }
}
