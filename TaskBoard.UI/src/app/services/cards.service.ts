import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card } from '../interfaces/card';

@Injectable({
  providedIn: 'root'
})
export class CardsService {

  constructor(private http: HttpClient) { }

  private apiUrl = `${environment.baseUrl}/Cards`;

  createCard(card: Card): Observable<any> {
    console.log("createCard [request]");
    
    console.log(this.apiUrl, card);
    return this.http.post(this.apiUrl, card);
  }

  updateCard(id: number, card: Card): Observable<any> {
    return this.http.patch(`${this.apiUrl}/${id}`, card);
  }

  deleteCard(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
