import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  inject,
} from '@angular/core';
import { Card } from '../../interfaces/card';
import { DropdownButtonComponent } from '../../Shared/Components/dropdown-button/dropdown-button.component';
import { ColumnComponent } from '../column/column.component';
import { ColumnService } from '../../services/column.service';
import { CommonModule } from '@angular/common';
import { DropdownConfig } from '../../Shared/Components/dropdown-button/dropdown-config';
import { CardsService } from '../../services/cards.service';
import { CardModalComponent } from '../card-modal/card-modal.component';
import { Observable } from 'rxjs';
import { Column } from '../../interfaces/column';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [
    DropdownButtonComponent,
    ColumnComponent,
    CommonModule,
    CardModalComponent,
  ],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css',
})
export class CardComponent implements OnInit {
  @Input() card!: Card;
  @Input() columnName!: string;
  @Output() cardsUpdated = new EventEmitter<number>();

  columnList$!: Observable<Column[]>;

  dropdownConfig!: DropdownConfig<number>;

  columnService: ColumnService = inject(ColumnService);
  cardService: CardsService = inject(CardsService);

  ngOnInit() {
    this.columnList$ = this.columnService.getColumns();

    this.columnList$.subscribe((data) => {
      this.dropdownConfig = {
        buttonText: 'Move to:',
        menuItems: data.map((column) => {
          return { id: column.id!, itemName: column.name };
        }),
      };
    });
  }

  onEditFormSubmitted(card: Card) {
    card.id = this.card.id;
    this.cardService
      .updateCard(this.card.id!, card)
      .subscribe(() => this.cardsUpdated.emit(this.card.id!));
  }

  onDeleteOptionSelected() {
    this.cardService
      .deleteCard(this.card.id!)
      .subscribe(() => this.cardsUpdated.emit(this.card.id!));
  }

  onSelectedValueChanged(targetColumn: { id: number; itemName: string }) {
    this.card.columnId = targetColumn.id;
    this.cardService
      .updateCard(this.card.id!, this.card)
      .subscribe(() => this.cardsUpdated.emit(this.card.id!));
  }
}
