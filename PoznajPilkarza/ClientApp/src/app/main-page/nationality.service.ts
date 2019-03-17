import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { INationality } from '../models/nationality';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NationalityService {

  private apiUrl = 'http://localhost:1234/api/nationalities/players';
  constructor(private http: HttpClient) { }

  getNationality() {
    return this.http.get<INationality[]>(this.apiUrl);
  }
}
