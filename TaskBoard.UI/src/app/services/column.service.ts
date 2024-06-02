import { Injectable } from '@angular/core';
import { Column } from '../interfaces/column';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, switchMap } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ColumnService {
  private apiUrl = `${environment.baseUrl}/Columns`;

  private columnsSubject = new BehaviorSubject<Column[]>([]);
  columns$ = this.columnsSubject.asObservable();

  constructor(private http: HttpClient) {
    this.loadColumns();
  }

  getColumns(): Observable<Column[]> {
    return this.columns$;
  }

  loadColumns(): void {
    console.log("loadColumns!");

    this.http.get<Column[]>(this.apiUrl).subscribe((data) => {
      this.columnsSubject.next(data);
    });
  }

  createColumn(column: Column): void {
    this.http.post<Column>(this.apiUrl, column).subscribe((createdColumn) => {
      const currentColumns = this.columnsSubject.value;
      this.columnsSubject.next([...currentColumns, createdColumn]);
    });
  }

  getColumnById(id: number): Observable<Column> {
    return this.http.get<Column>(`${this.apiUrl}/${id}`);
  }

  updateColumn(id: number, column: Column): void {
    console.log("updateColumn");
    
    this.http
      .patch(`${this.apiUrl}/${id}`, column)
      .pipe(switchMap(() => this.getColumnById(id)))
      .subscribe((createdColumn) => {
        const currentColumns = this.columnsSubject.value.map((c) =>
          c.id === id ? createdColumn : c
        );
        this.columnsSubject.next(currentColumns);
      });
  }

  deleteColumn(id: number): void {
    this.http.delete(`${this.apiUrl}/${id}`).subscribe(() => {
      const currentColumns = this.columnsSubject.value.filter(
        (column) => column.id !== id
      );
      this.columnsSubject.next(currentColumns);
    });
  }
}
