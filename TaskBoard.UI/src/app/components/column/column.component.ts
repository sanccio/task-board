import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  inject,
} from '@angular/core';
import { CardComponent } from '../card/card.component';
import { CommonModule } from '@angular/common';
import { Column } from '../../interfaces/column';
import { DropdownButtonComponent } from '../../Shared/Components/dropdown-button/dropdown-button.component';
import { FormsModule } from '@angular/forms';
import { ColumnService } from '../../services/column.service';
import { ThreeDotsMenuComponent } from '../../Shared/Components/three-dots-menu/three-dots-menu.component';
import { CardModalComponent } from '../card-modal/card-modal.component';
import { ColumnFormComponent } from '../column-form/column-form.component';
import { Card } from '../../interfaces/card';
import { CardsService } from '../../services/cards.service';

@Component({
  selector: 'app-column',
  standalone: true,
  imports: [
    CardComponent,
    CommonModule,
    DropdownButtonComponent,
    FormsModule,
    ThreeDotsMenuComponent,
    CardModalComponent,
    ColumnFormComponent,
  ],
  templateUrl: './column.component.html',
  styleUrl: './column.component.css',
})
export class ColumnComponent {
  @Input() column!: Column;
  @Output() columnsUpdated = new EventEmitter<number>();

  columnService: ColumnService = inject(ColumnService);
  cardService: CardsService = inject(CardsService);

  isEditFormVisible: boolean = false;

  onCardsUpdated() {
    this.columnsUpdated.emit(this.column.id);
  }

  onEditOptionSelected() {
    this.isEditFormVisible = true;
  }

  onDeleteOptionSelected(columnId: number) {
    this.columnService.deleteColumn(columnId);
  }

  onEditFormSubmitted(columnName: string) {
    this.column.name = columnName;
    this.columnService.updateColumn(this.column.id!, this.column);
    this.isEditFormVisible = false;
  }

  onEditFormCanceled() {
    this.isEditFormVisible = false;
  }

  onCreateCardFormSubmitted(card: Card) {
    this.cardService.createCard(card).subscribe(() => {
      this.columnsUpdated.emit(this.column.id);
    });
  }

  onInputFocused(id: number) {
    console.log('input_create_card_' + id);

    setTimeout(() => {
      const input = document.getElementById('input_create_card_' + id);
      input?.focus();
    }, 0);
  }
}
