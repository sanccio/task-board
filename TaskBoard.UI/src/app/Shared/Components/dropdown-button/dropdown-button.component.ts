import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DropdownConfig } from './dropdown-config';

@Component({
  selector: 'app-dropdown-button',
  standalone: true,
  templateUrl: './dropdown-button.component.html',
  styleUrl: './dropdown-button.component.css',
})
export class DropdownButtonComponent<TId> {
  @Input() config!: DropdownConfig<TId>;
  @Input() selectedItem!: string;
  @Output() selectedValueChanged = new EventEmitter<{
    id: TId;
    itemName: string;
  }>();

  setSelectedValue(value: { id: TId; itemName: string }) {
    this.selectedValueChanged.emit(value);
  }
}
