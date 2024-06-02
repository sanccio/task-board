import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { CardComponent } from '../card/card.component';
import { CommonModule } from '@angular/common';
import { Column } from '../../interfaces/column';
import { DropdownButtonComponent } from '../../Shared/Components/dropdown-button/dropdown-button.component';
import { FormsModule } from '@angular/forms';
import { ColumnService } from '../../services/column.service';
import { ThreeDotsMenuComponent } from '../../Shared/Components/three-dots-menu/three-dots-menu.component';
import { DropdownConfig } from '../../Shared/Components/dropdown-button/dropdown-config';
import { Card } from '../../interfaces/card';
import { Priority } from '../../interfaces/priority';
import { PrioritiesService } from '../../services/priorities.service';
import { CardsService } from '../../services/cards.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-card-modal',
  standalone: true,
  imports: [
    CardComponent,
    CommonModule,
    DropdownButtonComponent,
    FormsModule,
    ThreeDotsMenuComponent,
  ],
  templateUrl: './card-modal.component.html',
  styleUrl: './card-modal.component.css',
})
export class CardModalComponent {
  @Input() column!: Column;
  @Input() card!: Card;
  @Input() modalId!: string;
  @Input() columnName!: string;
  @Input() isEditMode: boolean = false;
  @Output() formSubmitted = new EventEmitter<Card>();

  columnList$!: Observable<Column[]>;
  priorityList$!: Observable<Priority[]>;

  columnService: ColumnService = inject(ColumnService);
  prioritiesService: PrioritiesService = inject(PrioritiesService);
  cardsService: CardsService = inject(CardsService);

  cardName: string = '';

  listDropdownConfig!: DropdownConfig<number>;
  priorityDropdownConfig!: DropdownConfig<number>;
  selectedColumnId!: number;
  selectedPriorityId?: number;
  dueDate?: Date;
  cardDescription: string = '';

  ngOnInit() {
    if (this.isEditMode) {
      this.cardName = this.card.title;
      this.selectedColumnId = this.card.columnId;
      this.dueDate = this.card.dueDate;
      this.selectedPriorityId = this.card.priorityId;
      this.cardDescription = this.card.description;
    } else {
      this.selectedColumnId = this.column.id!;
    }

    this.initListDropdown();
    this.initPriorityDropdown();
  }

  initListDropdown() {
    this.columnList$ = this.columnService.getColumns();

    this.columnList$.subscribe((data) => {
      this.listDropdownConfig = {
        buttonText: this.isEditMode ? this.columnName : this.column.name,
        menuItems: data.map((column) => {
          return { id: column.id!, itemName: column.name };
        }),
      };
    });
  }

  initPriorityDropdown() {
    this.priorityList$ = this.prioritiesService.getPriorities();

    this.priorityList$.subscribe((data) => {
      this.priorityDropdownConfig = {
        buttonText: this.isEditMode
          ? this.card.priority!.name
          : 'Select priority',
        menuItems: data.map((priority) => {
          return { id: priority.id, itemName: priority.name };
        }),
      };
    });
  }

  onColumnChanged(selectedColumn: { id: number; itemName: string }) {
    this.selectedColumnId = selectedColumn.id;
    this.listDropdownConfig.buttonText = selectedColumn.itemName;
  }

  onPriorityChanged(selectedPriority: { id: number; itemName: string }) {
    this.selectedPriorityId = selectedPriority.id;
    this.priorityDropdownConfig.buttonText = selectedPriority.itemName;
  }

  onFormSubmitted() {
    let card: Card = {
      title: this.cardName,
      columnId: this.selectedColumnId,
      description: this.cardDescription,
      dueDate: this.dueDate,
      priorityId: this.selectedPriorityId,
    };

    this.formSubmitted.emit(card);
  }
}
