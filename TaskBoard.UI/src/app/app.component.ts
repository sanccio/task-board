import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ColumnComponent } from './components/column/column.component';
import { CardComponent } from './components/card/card.component';
import { Column } from './interfaces/column';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ColumnService } from './services/column.service';
import { ColumnFormComponent } from './components/column-form/column-form.component';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    ColumnComponent,
    CardComponent,
    CommonModule,
    FormsModule,
    ColumnFormComponent,
  ],
  templateUrl: './app.component.html',
  styleUrls: [
    './app.component.css',
    './components/column/column.component.css',
  ],
})
export class AppComponent implements OnInit {
  columnList$!: Observable<Column[]>;
  isFormVisible = false;

  columnService: ColumnService = inject(ColumnService);

  ngOnInit() {
    this.columnList$ = this.columnService.getColumns();
  }

  onAddColumnClicked() {
    this.isFormVisible = true;
  }

  onColumnCreateFormCanceled() {
    this.isFormVisible = false;
  }

  onColumnCreateFormSubmitted(columnName: string) {
    let column: Column = { name: columnName };
    this.columnService.createColumn(column);
    this.isFormVisible = false;
  }

  onColumnsUpdated() {
    this.columnService.loadColumns();
  }
}
