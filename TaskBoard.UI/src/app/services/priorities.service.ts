import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Priority } from '../interfaces/priority';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class PrioritiesService {
  private apiUrl = `${environment.baseUrl}/Priorities`;

  private prioritiesSubject = new BehaviorSubject<Priority[]>([]);
  priorities$ = this.prioritiesSubject.asObservable();

  constructor(private http: HttpClient) {
    this.loadPriorities();
  }

  getPriorities(): Observable<Priority[]> {
    return this.priorities$;
  }

  loadPriorities(): void {
    this.http
      .get<Priority[]>(this.apiUrl)
      .subscribe((data) => this.prioritiesSubject.next(data));
  }
}
