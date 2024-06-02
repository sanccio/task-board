import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-column-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './column-form.component.html',
  styleUrl: './column-form.component.css'
})
export class ColumnFormComponent {

  @Input() inputText: string = '';
  @Input() submitButtonText: string = '';

  @Output() submitted = new EventEmitter<string>();
  @Output() canceled = new EventEmitter<void>();

  onSubmit() {
    this.submitted.emit(this.inputText);
  }

  onCancel() {
    this.canceled.emit();
  }
}
