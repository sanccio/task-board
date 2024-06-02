import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-three-dots-menu',
  standalone: true,
  templateUrl: './three-dots-menu.component.html',
  styleUrl: './three-dots-menu.component.css',
})
export class ThreeDotsMenuComponent<TId> {
  @Input() itemId!: TId;
  @Input() bsMenuPosition: string = '';
  @Output() editOptionSelected = new EventEmitter<TId>();
  @Output() deleteOptionSelected = new EventEmitter<TId>();

  onEditSelected(id: TId) {
    this.editOptionSelected.emit(id);
  }

  onDeleteSelected(id: TId) {
    this.deleteOptionSelected.emit(id);
  }
}
